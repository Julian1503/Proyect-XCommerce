namespace Presentacion.Core.Rubro
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Rubro;
    using XCommerce.Servicio.Core.Rubro.DTOs;

    public partial class _00019_Rubro_ABM : FormularioAbm
    {
        private readonly IRubroServicio _RubroServicio;

        public _00019_Rubro_ABM(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _RubroServicio = new RubroServicio();
            Inicializador(entidadId);


            if (tipoOperacion == TipoOp.Eliminar || tipoOperacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion1, "Descripción");

        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento
            txtDescripcion1.KeyPress += Validacion.NoSimbolos;
            txtDescripcion1.KeyPress += Validacion.NoNumeros;

            txtDescripcion1.Focus();
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

            var rubro = _RubroServicio.ObtenerPorId(entidadId);

            // Datos Personales
            txtDescripcion1.Text = rubro.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoRubro = new RubroDto
            {
                Descripcion = txtDescripcion1.Text,
            };

            _RubroServicio.Insertar(nuevoRubro);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }

            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var RubroParaModificar = new RubroDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion1.Text
            };

            _RubroServicio.Modificar(RubroParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }

            if (EntidadId == null) return false;

            _RubroServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
