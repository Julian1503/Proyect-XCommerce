namespace Presentacion.Core.PlanTarjeta
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using Tarjeta;
    using XCommerce.Servicio.Core.PlanTarjeta;
    using XCommerce.Servicio.Core.PlanTarjeta.DTOs;
    using XCommerce.Servicio.Core.Tarjeta;
    using XCommerce.Servicio.Core.Tarjeta.DTOs;

    public partial class _00039_ABM_PlanTarjeta : FormularioAbm
    {

        private readonly IPlanTarjetaServicio _plantarjetaServicio;

        private readonly ITarjetaServicio _tarjetaServicio;

        public _00039_ABM_PlanTarjeta(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _tarjetaServicio = new TarjetaServicio();
            _plantarjetaServicio = new PlanTarjetaServicio();
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            if (tipoOperacion == TipoOp.Eliminar || tipoOperacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AgregarControlesObligatorios(nudAlicuota, "Alicuota");
            AgregarControlesObligatorios(cmbTarjeta, "Tarjeta");


            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento

            txtDescripcion.Focus();
            CargarComboBox(cmbTarjeta, _tarjetaServicio.Obtener(string.Empty), "Descripcion", "Id");

        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOp.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var plantarjeta = _plantarjetaServicio.ObtenerPorId(entidadId.Value);

            CargarComboBox(cmbTarjeta,_tarjetaServicio.Obtener(string.Empty),"Descripcion","Id");

            // Datos Personales
            txtDescripcion.Text = plantarjeta.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaPlanTarjeta = new PlanTarjetaDto
            {
                Descripcion = txtDescripcion.Text,
                Alicuota = nudAlicuota.Value,
                TarjetaId = ((TarjetaDto)cmbTarjeta.SelectedItem).Id
            };

            _plantarjetaServicio.Agregar(nuevaPlanTarjeta);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var plantarjetaParaModificar = new PlanTarjetaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Alicuota = nudAlicuota.Value,
                TarjetaId = ((TarjetaDto)cmbTarjeta.SelectedItem).Id
            };

            _plantarjetaServicio.Modificar(plantarjetaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _plantarjetaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void btnAgregarTarjeta_Click(object sender, System.EventArgs e)
        {
            var fTarjeta = new _00041_ABM_Tarjeta(TipoOp.Nuevo);
            fTarjeta.ShowDialog();
            if(fTarjeta.RealizoAlgunaOperacion)
                CargarComboBox(cmbTarjeta, _tarjetaServicio.Obtener(string.Empty), "Descripcion", "Id");

        }
    }
}
