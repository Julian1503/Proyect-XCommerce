namespace Presentacion.Core.MotivoBaja
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.MotivoBaja;
    using XCommerce.Servicio.Core.MotivoBaja.DTOs;

    public partial class _00012_ABM_MotivoBaja : FormularioAbm
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        public _00012_ABM_MotivoBaja(TipoOp operacion, long? entidadId = null) :base(operacion,entidadId)
        {
            InitializeComponent();
            _motivoBajaServicio = new MotivoBajaServicio();
            if (TipoOp.Modificar == operacion)
            {
                CargarDatos(entidadId);
            }
            if (operacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);
            AgregarControlesObligatorios(txtDescripcion,"Descripcion");
            Inicializador(entidadId);
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            base.CargarDatos(entidadId);
            var motivo = _motivoBajaServicio.ObtenerPorId(entidadId);
            txtDescripcion.Text = motivo.Descripcion;
        }

        public override void Inicializador(long? entidadId)
        {
            txtDescripcion.KeyPress += Helpers.Validacion.NoSimbolos;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            var motivo = new MotivoBajaDto();
            motivo.Descripcion = txtDescripcion.Text;
            _motivoBajaServicio.Agregar(motivo);
            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _motivoBajaServicio.Eliminar(EntidadId.Value);

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

            var motivo = new MotivoBajaDto()
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };
            _motivoBajaServicio.Modificar(motivo);
            return true;
        }
    }
}
