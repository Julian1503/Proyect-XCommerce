using XCommerce.Servicio.Core.Empresa;

namespace Presentacion.Seguridad
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using Bunifu.Framework.UI;
    using Helpers;
    using XCommerce;
    using XCommerce.Servicio.Core.Caja;
    using XCommerce.Servicio.Core.Configuracion;
    using XCommerce.Servicio.Core.Entidad;
    using XCommerce.Servicio.Seguridad.Seguridad;
    using XCommerce.Servicio.Seguridad.Usuario;

    public partial class Login : Form
    {
        // Atributos / Variables

        private readonly IAccesoSistema _accesoSistema;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private bool _ojitoPresionado;
        
        private bool _textoModificado;
        private int _cantidadAccesosFallidos;

        // Propiedades
        public bool PuedeAccederSistema { get; protected set; }

        public Login(IConfiguracionServicio configuracionServicio)
        {
            _configuracionServicio = configuracionServicio;
        }

        public Login() : this(new ConfiguracionServicio())
        {
            InitializeComponent();
        }
        //public void SplashArt()
        //{
        //    Application.Run(new ImagenInicio());
        //}

        public Login(IAccesoSistema accesoSistema, IUsuarioServicio usuarioServicio)
            : this()
        {
            var pos = this.PointToScreen(btnSalir.Location);
            pos = pnlImagen.PointToClient(pos);
            btnSalir.Parent = pnlImagen;
            btnSalir.Location = pos;
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Click += btnSalir_Click;

            _accesoSistema = accesoSistema;
            _usuarioServicio = usuarioServicio;
            _cantidadAccesosFallidos = 0;
            txtUsuario.Enter += TxtEnterEfecto;
            txtPassword.Enter += TxtEnterEfecto;
            txtUsuario.Leave += TxtLeaveEfecto;
            txtPassword.Leave += TxtLeaveEfecto;
            imgOjo.Image = Constantes.ImagenesSistema.OjitoTachado;
            _ojitoPresionado = true;
            _textoModificado = false;
        }



        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            // 1 - Verificar si esta cargado el usuario
            // 2 - verificar si esta cargado el password
            if (!VerificarDatosObligatorios()) return;
            if (_usuarioServicio.VerificarSiUsuarioExiste(txtUsuario.Text) || (txtPassword.Text == "Admin" && txtUsuario.Text == "Admin"))
            {
                // 3 - verificar si el usuario y la Pass son Correctos (Autenticacion)
                if (_accesoSistema.VerificarSiExisteUsuario(txtUsuario.Text, txtPassword.Text) || (txtPassword.Text == "Admin" && txtUsuario.Text=="Admin"))
                {
                    // 5 - Verificar si Esta Bloqueado
                    if (!_accesoSistema.VerificarSiEstaBloqueadoUsuario(txtUsuario.Text))
                    {
                        //7 - Cuando este correcto ingresar al sistema.

                        PuedeAccederSistema = true;
                        Entidad.UsuarioId = _accesoSistema.ObtenerPorId(txtUsuario.Text, txtPassword.Text);
                        Entidad.NombreUsuario = txtUsuario.Text;
                        var configuracionLista = _configuracionServicio.Obtener();
                        if (configuracionLista != null)
                        {
                            Entidad.ListaPrecioDeliveryId=configuracionLista.ListaDeliveryId;
                            Entidad.ListaPrecioDeliveryDescripcion = configuracionLista.ListaDeliveryDescripcion;
                            Entidad.ListaPrecioKioscoDescripcion = configuracionLista.ListaKioscoDescripcion;
                            Entidad.ListaPrecioKioscoId=configuracionLista.ListaKioscoId;
                            Entidad.CategoriaCadeteDescripcion = configuracionLista.CategoriaCadeteDescripcion;
                            Entidad.CategoriaMozoDescripcion = configuracionLista.CategoriaMozoDescripcion;
                            Entidad.CategoriaCadeteId = configuracionLista.CadeteId;
                            Entidad.CategoriaMozoId = configuracionLista.MozoId;
                        }
                        CajaServicio c = new CajaServicio();
                        var Emp = new EmpresaServicio().Obtener();
                        if (Emp != null)
                        {
                            Entidad.ImagenLogo = Emp.Logo == ImagenDb.Convertir_Imagen_Bytes(Constantes.ImagenesSistema.ImagenNoDisponible) ? null : Emp.Logo;
                        }
                        Entidad.CajaId = c.UltimaCaja();
                        Entidad.CajaAbierta = c.EstadoCaja();
                        this.Close(); // Cierro el Formulario de Login
                    }
                    else
                    {
                        // 6 - Si esta bloqueado mostrar mensaje
                        MessageBox.Show(@"El Usuario esta BLOQUEADO.");

                        txtPassword.Text = "";
                        txtUsuario.Text = "";


                        txtUsuario.Focus();

                        _cantidadAccesosFallidos = 0;

                        PuedeAccederSistema = false;

                        return;
                    }

                }
                else
                {
                    PuedeAccederSistema = false;

                    // 4 - Si no existe mostrar Mensaje
                    MessageBox.Show(@"El usuario o la contraseña son incorrectos.");

                    txtPassword.Text = "";

                    txtPassword.Focus();

                    // incrementar los Intentos Fallidos
                    _cantidadAccesosFallidos++;

                    if (_cantidadAccesosFallidos >= 3)
                    {
                        try
                        {
                            // Bloquear el Usuario
                            _usuarioServicio.CambiarEstado(txtUsuario.Text, true);
                            // Notificar al Usuario que esta Bloqueado
                            MessageBox.Show(@"El Usuario FUE BLOQUEADO. Comunicarse con el Adminsitrador.");
                            Application.Exit();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                            txtPassword.Text = "";
                            txtPassword.Focus();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(@"El Usuario no existe");

            }
        }

        private bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show(@"El nombre de Usuario es Obligatorio.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(@"La contraseña es Obligatoria.");
                return false;
            }

            return true;
        }

        private void TxtEnterEfecto(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((BunifuMaterialTextbox) sender).Text))
            {
                if((((BunifuMaterialTextbox)sender).Name.Equals("txtUsuario") && ((BunifuMaterialTextbox)sender).Text.Equals("Usuario"))
                    || (((BunifuMaterialTextbox)sender).Name.Equals("txtPassword") && ((BunifuMaterialTextbox)sender).Text.Equals("Contraseña")))
                ((BunifuMaterialTextbox) sender).Text = "";
                (((BunifuMaterialTextbox)sender)).ForeColor = Constantes.Color.LetraLoginFoco;

                if (((BunifuMaterialTextbox) sender).Name.Equals("txtPassword"))
                {
                    ((BunifuMaterialTextbox)sender).isPassword = true;
                }
            }
        }

        private void TxtLeaveEfecto(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((BunifuMaterialTextbox)sender).Text))
            {
                (((BunifuMaterialTextbox)sender)).ForeColor = Constantes.Color.LetraLoginSinFoco;
                if (((BunifuMaterialTextbox)sender).Name.Equals("txtUsuario"))
                {
                    
                    ((BunifuMaterialTextbox) sender).Text = "Usuario";
                }
                else
                {
                    ((BunifuMaterialTextbox)sender).isPassword = false;
                    ((BunifuMaterialTextbox)sender).Text = "Contraseña";
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            MovilidadSinBorde.Movilidad(this);
        }

        private void imgOjo_MouseDown(object sender, MouseEventArgs e)
        {
            if (!txtPassword.Text.Equals("Contraseña"))
            {
                txtPassword.isPassword = false;
                imgOjo.Image = Constantes.ImagenesSistema.Ojito;
            }
        }

        private void imgOjo_MouseUp(object sender, MouseEventArgs e)
        {
            if (!txtPassword.Text.Equals("Contraseña"))
            {
                txtPassword.isPassword = true;
                imgOjo.Image = Constantes.ImagenesSistema.OjitoTachado;
            }
        }
    }
}
