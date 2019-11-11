using Presentacion.Core.VentasSalon;

namespace XCommerce
{
    using Bunifu.Framework.UI;
    using Presentacion.Constantes;
    using Presentacion.Core.Articulo;
    using Presentacion.Core.BajaArticulo;
    using Presentacion.Core.Banco;
    using Presentacion.Core.Caja;
    using Presentacion.Core.Cliente;
    using Presentacion.Core.CondicionIva;
    using Presentacion.Core.Configuracion;
    using Presentacion.Core.ControlPresentacion;
    using Presentacion.Core.Delivery;
    using Presentacion.Core.Empleado;
    using Presentacion.Core.Empresa;
    using Presentacion.Core.ListaPrecio;
    using Presentacion.Core.ListaPrecios;
    using Presentacion.Core.Localidad;
    using Presentacion.Core.Marca;
    using Presentacion.Core.Mesa;
    using Presentacion.Core.MotivoBaja;
    using Presentacion.Core.MotivoReserva;
    using Presentacion.Core.Movimientos;
    using Presentacion.Core.PlanTarjeta;
    using Presentacion.Core.Precio;
    using Presentacion.Core.Proveedor;
    using Presentacion.Core.Provincia;
    using Presentacion.Core.Reserva;
    using Presentacion.Core.Rubro;
    using Presentacion.Core.Salon;
    using Presentacion.Core.Tarjeta;
    using Presentacion.Core.Usuario;
    using Presentacion.Core.Venta;
    using Presentacion.Core.VentaKiosco;
    using Presentacion.Helpers;
    using Servicio.Core.Entidad;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Empleado;
    using XCommerce.Servicio.Seguridad.Usuario;
    using MessageBox = System.Windows.Forms.MessageBox;

    public partial class Principal : Form
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        public Principal()
        {
            _empleadoServicio = new EmpleadoServicio();
            InitializeComponent();
            if (Entidad.UsuarioId != 0)
            {
                controlPresentacion1.lblUsuario.Text = Entidad.NombreUsuario;
                controlPresentacion1.pbEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(_empleadoServicio.ObtenerPorUsuarioId(Entidad.UsuarioId).Foto);
            }
        }

        private void consultaDeEmpleadosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fEmpleados = new _00001_Empleados();
            fEmpleados.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fProvincia = new _00005_Provincia();
            fProvincia.ShowDialog();
        }

        private void nuevaProvinciaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincia_ABM(TipoOp.Nuevo);
            fNuevaProvincia.ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fLocalidad = new _00007_Localidad();
            fLocalidad.ShowDialog();
        }

        private void nuevaLocalidadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOp.Nuevo);
            fNuevaLocalidad.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            NuevoEmpleado();
        }

        private static void NuevoEmpleado()
        {
            var fNuevoEmpleado = new _00002_ABM_Empleados(TipoOp.Nuevo);
            fNuevoEmpleado.ShowDialog();
        }

        private void consultaToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            var fClientes = new _00003_Clientes();
            fClientes.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            NuevoCliente();
        }

        private static void NuevoCliente()
        {
            var fClienteAbm = new _00004_ABM_Cliente(TipoOp.Nuevo);
            fClienteAbm.ShowDialog();
        }

        private void cToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMotivo = new _00011_MotivoBaja();
            fMotivo.ShowDialog();
        }

        private void nuevoMotivoDeBajaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMotivo = new _00012_ABM_MotivoBaja(TipoOp.Nuevo);
            fMotivo.ShowDialog();
        }

        private void consultaDeBajaDeArticuloToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fBaja = new _00013_BajaArticulos();
            fBaja.ShowDialog();
        }

        private void nuevaBajaDeArticulosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fBaja = new _00014_ABM_BajaArticulo(TipoOp.Nuevo);
            fBaja.ShowDialog();
        }


        private void consultaMarcasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMarca = new _00016_Marca();
            fMarca.ShowDialog();
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMarca = new _00017_Marca_ABM(TipoOp.Nuevo);
            fMarca.ShowDialog();
        }

        private void consultaRubrosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fRubro = new _00018_Rubro();
            fRubro.ShowDialog();
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fRubro = new _00019_Rubro_ABM(TipoOp.Nuevo);
            fRubro.ShowDialog();
        }

        private void consultaToolStripMenuItem4_Click(object sender, System.EventArgs e)
        {
            var fProv = new _00031_Proveedores();
            fProv.ShowDialog();
        }

        private void aBMToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fProv = new _00032_Proveedores_ABM(TipoOp.Nuevo);
            fProv.ShowDialog();
        }

        private void consultaToolStripMenuItem5_Click(object sender, System.EventArgs e)
        {
            var fbanco = new _00021_Banco();
            fbanco.ShowDialog();
        }

        private void aBMToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fbanco = new _00022_ABM_Banco(TipoOp.Nuevo);
            fbanco.ShowDialog();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fUsu = new _00015_Usuarios();
            fUsu.ShowDialog();
        }

        private void consultaProductoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fArticulos = new _00009_Articulos();
            fArticulos.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            NuevoArticulo();
        }

        private static void NuevoArticulo()
        {
            var fArticulo = new _00010_ABM_Articulo(TipoOp.Nuevo);
            fArticulo.ShowDialog();
        }

        private void consultaToolStripMenuItem10_Click(object sender, System.EventArgs e)
        {
            var fSalon = new _00027_Salon();
            fSalon.ShowDialog();
        }

        private void nuevoSalonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fSalon = new _00028_ABM_Salon(TipoOp.Nuevo);
            fSalon.ShowDialog();
        }

        private void consultaToolStripMenuItem9_Click(object sender, System.EventArgs e)
        {
            var fMesa = new _00035_Mesa();
            fMesa.ShowDialog();
        }

        private void nuevaMesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMesa = new _00036_ABM_Mesa(TipoOp.Nuevo);
            fMesa.ShowDialog();
        }

        private void consultaToolStripMenuItem4_Click_1(object sender, System.EventArgs e)
        {
            var fCondicion = new _00023_CondicionIva();
            fCondicion.ShowDialog();
        }

        private void nuevaCondicionIvaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fCondicion = new _00024_ABM_CondicionIva(TipoOp.Nuevo);
            fCondicion.ShowDialog();
        }

        private void consultaToolStripMenuItem11_Click(object sender, System.EventArgs e)
        {
            if (Entidad.UsuarioId != 0)
            {
                var fReserva = new _00029_Reserva();
                fReserva.ShowDialog();
            controlPresentacion1.lblNumeroReservas.Refresh();
            }
            else
            {
                MessageBox.Show("Debe estar logueado con una cuenta de usuario!");
            }
            
        }

        private void nuevaReservaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (Entidad.UsuarioId != 0)
            {

                var fReserva = new _00030_ABM_Reserva(TipoOp.Nuevo);
                fReserva.ShowDialog();
                if (fReserva.RealizoAlgunaOperacion)
                {
                    controlPresentacion1.lblNumeroReservas.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Debe estar logueado con una cuenta de usuario!");

            }
        }

        private void consultaToolStripMenuItem12_Click(object sender, System.EventArgs e)
        {
            var fMotivoReserva = new _00033_MotivoReserva();
            fMotivoReserva.ShowDialog();
        }

        private void nuevoMotivoDeReservaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMotivoReserva = new _00034_ABM_MotivoReserva(TipoOp.Nuevo);
            fMotivoReserva.ShowDialog();
        }

        private void consultaToolStripMenuItem13_Click(object sender, System.EventArgs e)
        {
            var fTarjeta = new _00040_Tarjeta();
            fTarjeta.ShowDialog();
        }

        private void nuevaTrjetaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fTarjeta = new _00041_ABM_Tarjeta(TipoOp.Nuevo);
            fTarjeta.ShowDialog();
        }

        private void consultaToolStripMenuItem14_Click(object sender, System.EventArgs e)
        {
            var fPlanTarjeta = new _00038_PlanTarjeta();
            fPlanTarjeta.ShowDialog();
        }

        private void nuevoPlanTarjetaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fPlanTarjeta = new _00039_ABM_PlanTarjeta(TipoOp.Nuevo);
            fPlanTarjeta.ShowDialog();
        }

        private void datosDeLaEmpresaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fEmpresa = new _00020_Empresa();
            if (fEmpresa.hayDatos)
            {
                var fDatos = new _00042_DatosEmpresa();
                fDatos.ShowDialog();
            }
            else
            {
                fEmpresa.ShowDialog();
                if (fEmpresa.RealizoOperacion)
                {
                    var fDatos = new _00042_DatosEmpresa();
                    fDatos.Show();
                }
            }
        }

        private void ventasSalonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AbrirVentaSalon();

        }

        private void AbrirVentaSalon()
        {
            if (Entidad.CajaAbierta)
            {
                if (Entidad.UsuarioId != 0)
                {
                    var fVentas = new _00038_VentaSalon();
                    fVentas.ShowDialog();
                    controlPresentacion1.lblVentasHoy.Refresh();
                }
                else
                {
                    MessageBox.Show("Debe estar logueado con una cuenta de usuario!");

                }
            }
            else

            {
                MessageBox.Show("Debe tener caja abierta para facturar", "Cuidado!", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void actualizacionDePreciosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fPrecio = new _00044_Precio();
            fPrecio.ShowDialog();
        }

        private void consultaToolStripMenuItem15_Click(object sender, System.EventArgs e)
        {
            var fLista = new _00025_ListaPrecios();
            fLista.ShowDialog();
        }

        private void nuevaListaDePreciosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fLista = new _00026_ABM_ListaPrecios(TipoOp.Nuevo);
            fLista.ShowDialog();
        }


        private void ventasKioscoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (Entidad.ListaPrecioKioscoId == null)
            {
                MessageBox.Show("No puede ejecutar kiosco sin tener configurada la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
                AbrirKiosco();
        }

        private void AbrirKiosco()
        {
            if (Entidad.CajaAbierta)
            {
                if (Entidad.UsuarioId != 0)

                {
                    var fkios = new _0003_Ventakiosco();
                    fkios.ShowDialog();
                    controlPresentacion1.lblVentasHoy.Refresh();
                }

                else
                {
                    MessageBox.Show("Debe estar logueado con una cuenta de usuario!");

                }
            }
            else
            {
                MessageBox.Show("Debe tener caja abierta para facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void movimientosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fmov = new _10010_Movimiento();
            fmov.ShowDialog();
        }

        private void empresaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fEmp = new _00020_Empresa();
            if (fEmp.hayDatos)
            {
                var fdat = new _00042_DatosEmpresa();
                fdat.ShowDialog();
            }
            else
            {
                fEmp.ShowDialog();
            }
        }

        private void ctacteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fCta = new _10009_CtaCte();
            fCta.ShowDialog();
        }

        private void cajaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var caja = new _00011_Caja();
            caja.ShowDialog();

        }

        private void configuracionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fConfiguracion = new Configuracion();
            if (!fConfiguracion.HayLista)
            {
                MessageBox.Show("Debe cargar alguna lista antes de configurar", "Advertencia",  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            fConfiguracion.ShowDialog();
        }

        private void deliveryToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (Entidad.ListaPrecioDeliveryId == null)
            {
                MessageBox.Show("No puede ejecutar delivery sin tener configurada la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!Entidad.CajaAbierta)
            {
                MessageBox.Show("Debe tener caja abierta para facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var prov = new DeliveryMenu();
            prov.ShowDialog();
            controlPresentacion1.lblEnviosHoy.Refresh();
            controlPresentacion1.lblVentasHoy.Refresh();
        }

        private void compraToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (!Entidad.CajaAbierta)
            {
                MessageBox.Show("Debe tener caja abierta para facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var fCompra = new ComprasRealizadas();
            fCompra.ShowDialog();
        }

        private void BunifuFlatButton1_Click(object sender, System.EventArgs e)
        {
            ((BunifuFlatButton)sender).selected = !((FlowLayoutPanel)((BunifuFlatButton)sender).Parent.Controls[$"pnl{((BunifuFlatButton)sender).Tag}"]).Visible;
            ((FlowLayoutPanel)((BunifuFlatButton)sender).Parent.Controls[$"pnl{((BunifuFlatButton)sender).Tag}"]).Visible = !((FlowLayoutPanel)((BunifuFlatButton)sender).Parent.Controls[$"pnl{((BunifuFlatButton)sender).Tag}"]).Visible;
        }

        private void FlowLayoutPanel2_VisibleChanged(object sender, System.EventArgs e)
        {
            
            if (((FlowLayoutPanel)sender).Visible)
            {
                ((FlowLayoutPanel)sender).Size = ((FlowLayoutPanel)sender).MaximumSize;
            }
            else
            {
                ((FlowLayoutPanel)sender).Size = ((FlowLayoutPanel)sender).MinimumSize;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MovilidadSinBorde.Movilidad(this);
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, System.EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                btnMaximizar.Image = ImagenesSistema.MaximizarVentana;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                btnMaximizar.Image = ImagenesSistema.NormalVentana;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnSalir_Click_1(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}