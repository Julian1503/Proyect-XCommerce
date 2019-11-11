namespace Presentacion.Core.MotivoReserva
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.MotivoReserva;
    using XCommerce.Servicio.Core.MotivoReserva.DTOs;

    public partial class _00034_ABM_MotivoReserva : FormularioAbm
    {
  

        private readonly IMotivoReservaServicio _motivoreservaServicio;

        public _00034_ABM_MotivoReserva(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _motivoreservaServicio = new MotivoReservaServicio();

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

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;

            txtDescripcion.Focus();
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

            var motivoreserva = _motivoreservaServicio.ObtenerPorId(entidadId.Value);

            // Datos Descripcion
            txtDescripcion.Text = motivoreserva.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaMotivoReserva = new MotivoReservaDto
            {
                Descripcion = txtDescripcion.Text,
            };

            _motivoreservaServicio.Agregar(nuevaMotivoReserva);

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

            var motivoServicioParaModificar = new MotivoReservaDto()
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _motivoreservaServicio.Modificar(motivoServicioParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _motivoreservaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void _00006_Provincia_ABM_Load(object sender, System.EventArgs e)
        {

        }
    }
}
