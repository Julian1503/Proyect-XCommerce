using XCommerce.Servicio.Core.Entidad;

namespace Presentacion.Core.Empresa
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using CondicionIva;
    using Constantes;
    using Helpers;
    using Localidad;
    using Provincia;
    using XCommerce.Servicio.Core.CondicionIva;
    using XCommerce.Servicio.Core.CondicionIva.DTOs;
    using XCommerce.Servicio.Core.Empresa;
    using XCommerce.Servicio.Core.Empresa.DTOs;
    using XCommerce.Servicio.Core.Localidad;
    using XCommerce.Servicio.Core.Localidad.DTOs;
    using XCommerce.Servicio.Core.Provincia;
    using XCommerce.Servicio.Core.Provincia.DTOs;

    public partial class _00020_Empresa : FormularioBase.FormularioBase
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;
        public bool RealizoOperacion;
        public bool hayDatos;

        public _00020_Empresa()
        {
            InitializeComponent();
            _empresaServicio = new EmpresaServicio();
            _provinciaServicio=new ProvinciaServicio();
            _localidadServicio=new LocalidadServicio();
            _condicionIvaServicio=new CondicionIvaServicio();
            RealizoOperacion = false;
            AsignarBotones();
            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtNombreFantasia, "Nombre Fantasia");
            AgregarControlesObligatorios(txtRazonSocial, "Razon Social");
            AgregarControlesObligatorios(txtSucursal, "Sucursal");
            AgregarControlesObligatorios(txtCuit, "CUIT");
            AgregarControlesObligatorios(cmdCondicionIva, "Condicion Iva");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");
            AgregarControlesObligatorios(txtEmail, "E-Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");
            hayDatos = _empresaServicio.HayDatos();
            Validaciones();
            if (hayDatos)
            {
                CargarDatos();
            }

            Inicializar();
        }

        private void Validaciones()
        {
            txtCuit.KeyPress += Validacion.NoSimbolos;
            txtCuit.KeyPress += Validacion.NoLetras;

            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;
            txtDepartamento.KeyPress += Validacion.NoNumeros;
            txtDepartamento.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoLetras;
            txtCasa.KeyPress += Validacion.NoSimbolos;
            txtLote.KeyPress += Validacion.NoSimbolos;
            txtManzana.KeyPress += Validacion.NoSimbolos;

            txtNumero.KeyPress += Validacion.NoSimbolos;
            txtNumero.KeyPress += Validacion.NoLetras;
        }

        private void Inicializar()
        {
            if (hayDatos) return;
            
            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmdCondicionIva, _condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");
            if (cmbProvincia.Items.Count > 0)
            {
                var provincia = (ProvinciaDto)cmbProvincia.Items[0];

                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(provincia.Id, string.Empty), "Descripcion", "Id");
            }

            imgLogo.Image = ImagenesSistema.ImagenNoDisponible;
        }

        private void AsignarBotones()
        {
            btnEjecutar.Text = @"Guardar";
            btnEjecutar.Image = Constantes.ImagenesSistema.Guardar;
            btnLimpiar.Image = Constantes.ImagenesSistema.Actualizar;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
        }

        private void _00020_Empresa_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            var empresa = _empresaServicio.Obtener();
            txtNumero.Text = empresa.Numero.ToString();
            txtTelefono.Text = empresa.Telefono;
            txtRazonSocial.Text = empresa.RazonSocial;
            txtEmail.Text = empresa.Mail;
            txtSucursal.Text = empresa.Sucursal;
            txtCuit.Text = empresa.Cuit;
            imgLogo.Image = ImagenDb.Convertir_Bytes_Imagen(empresa.Logo);
            txtNombreFantasia.Text = empresa.NombreFantasia;
            txtBarrio.Text = empresa.Barrio;
            txtCalle.Text = empresa.Calle;
            txtCasa.Text = empresa.Casa;
            txtDepartamento.Text = empresa.Dpto;
            txtLote.Text = empresa.Lote;
            txtManzana.Text = empresa.Mza;
            txtPiso.Text = empresa.Piso;
           
            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbProvincia.SelectedItem = empresa.ProvinciaId;
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(empresa.ProvinciaId, string.Empty), "Descripcion", "Id");
            }
            cmbLocalidad.SelectedItem = empresa.LocalidadId;
            CargarComboBox(cmdCondicionIva, _condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmdCondicionIva.SelectedItem = empresa.CondicionIvaId;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta seguro de Limpiar los Datos", @"Atención", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(this);
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            EjecutarComando();
        }

        private void EjecutarComando()
        {
            if (hayDatos)
            {
                if (EjecutarComandoModificar())
                {
                    MessageBox.Show(@"Los datos se Modificaron Correctamente.", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    RealizoOperacion = true;
                    this.Close();
                }
            }
            else
            {
                if (EjecutarComandoNuevo())
                {
                    MessageBox.Show(@"Los datos se Guardaron Correctamente.", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    RealizoOperacion = true;
                    this.Close();
                }
            }
        }

        private bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

CamposVacios();
            var empresa = new EmpresaDto
            {
                CondicionIvaId = ((CondicionIvaDto) cmdCondicionIva.SelectedItem).Id,
                Telefono = txtTelefono.Text,
                RazonSocial = txtRazonSocial.Text,
                Mail = txtEmail.Text,
                Sucursal = txtSucursal.Text,
                Cuit = txtCuit.Text,
                Logo = ImagenDb.Convertir_Imagen_Bytes(imgLogo.Image),
                NombreFantasia = txtNombreFantasia.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Dpto = txtDepartamento.Text,
                Lote = txtLote.Text,
                Mza = txtManzana.Text,
                Piso = txtPiso.Text,
                Numero = int.Parse(txtNumero.Text),
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                ProvinciaId = ((ProvinciaDto)cmbProvincia.SelectedItem).Id
            };
            _empresaServicio.Agregar(empresa);
            Entidad.ImagenLogo = empresa.Logo;
            return true;
        }

        private bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            CamposVacios();

            var empresa = new EmpresaDto
            {
                Numero = int.TryParse(txtNumero.Text, out var x) ? int.Parse(txtNumero.Text) : 0,
                CondicionIvaId = ((CondicionIvaDto)cmdCondicionIva.SelectedItem).Id,
                Telefono = txtTelefono.Text,
                RazonSocial = txtRazonSocial.Text,
                Mail = txtEmail.Text,
                Sucursal = txtSucursal.Text,
                Cuit = txtCuit.Text,
                Logo = ImagenDb.Convertir_Imagen_Bytes(imgLogo.Image),
                NombreFantasia = txtNombreFantasia.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Dpto = txtDepartamento.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                Lote = txtLote.Text,
                Mza = txtManzana.Text,
                Piso = txtPiso.Text,
                ProvinciaId = ((ProvinciaDto)cmbProvincia.SelectedItem).Id
            };
            _empresaServicio.Modificar(empresa);
            Entidad.ImagenLogo = empresa.Logo;
            return true;
        }
        private void CamposVacios()
        {
            if (string.IsNullOrEmpty(txtBarrio.Text))
            {
                txtBarrio.Text = "-";
            }
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                txtBarrio.Text = "-";
            }
            if (string.IsNullOrEmpty(txtCasa.Text))
            {
                txtCasa.Text = "-";
            }
            if (string.IsNullOrEmpty(txtLote.Text))
            {
                txtLote.Text = "-";
            }
            if (string.IsNullOrEmpty(txtManzana.Text))
            {
                txtManzana.Text = "-";
            }
            if (string.IsNullOrEmpty(txtDepartamento.Text))
            {
                txtDepartamento.Text = "-";
            }
            if (string.IsNullOrEmpty(txtPiso.Text))
            {
                txtPiso.Text = "-";
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Text = "S/N";
            }
        }

        private void CmbProvincia_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion",
                    "Id");
            }
        }
        private void BtnAgregarImagen_Click(object sender, System.EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgLogo.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgLogo.Image = Constantes.ImagenesSistema.PerfilVacio;
                }
            }
            else
            {
                imgLogo.Image = Constantes.ImagenesSistema.PerfilVacio;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarCondicionIva_Click(object sender, EventArgs e)
        {
            var fCondicionIva = new _00024_ABM_CondicionIva(TipoOp.Nuevo);
            fCondicionIva.ShowDialog();
            if(fCondicionIva.RealizoAlgunaOperacion)
                CargarComboBox(cmdCondicionIva, _condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincia_ABM(TipoOp.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (!fNuevaProvincia.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOp.Nuevo);
            fNuevaLocalidad.ShowDialog();

            if (!fNuevaLocalidad.RealizoAlgunaOperacion) return;
            if (fNuevaLocalidad.SeActualizoProvincia)
            {
                CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            }
            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
            
        }
    }
}
