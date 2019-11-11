namespace Presentacion.Core.CondicionIva
{
    using System.Windows.Forms;
    using Helpers;
    using XCommerce.Servicio.Core.CondicionIva;
    using XCommerce.Servicio.Core.CondicionIva.DTOs;

    public partial class _00024_ABM_CondicionIva : FormularioBase.FormularioAbm
    {
        private readonly ICondicionIvaServicio _condicionServicio;
        public _00024_ABM_CondicionIva(TipoOp operacion, long? entidadId = null) :base(operacion,entidadId)
        {
            InitializeComponent();
            _condicionServicio = new CondicionIvaServicio();

            Validaciones();
            if (operacion == TipoOp.Modificar ||
               operacion == TipoOp.Eliminar)
            {
                CargarDatos(entidadId);
            }


            if (operacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;
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

            var condicionIva = _condicionServicio.ObtenerPorId(entidadId.Value);
            txtDescripcion.Text = condicionIva.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var condicionIva = new CondicionIvaDto
            {
                Descripcion = txtDescripcion.Text
            };
            _condicionServicio.Agregar(condicionIva);
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
            var condicionIva = new CondicionIvaDto
            {
                Id =EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };
            _condicionServicio.Modificar(condicionIva);
            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;
            _condicionServicio.Eliminar(EntidadId.Value);
            return true;
        }
    }
}
