namespace Presentacion.Core.Marca
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Marca;
    using XCommerce.Servicio.Core.Marca.DTOs;

    public partial class _00017_Marca_ABM : FormularioAbm
    {
        

        private readonly IMarcaServicio _MarcaServicio;

        public _00017_Marca_ABM(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _MarcaServicio = new MarcaServicio();

            Validaciones();
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

            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtDescripcion1.KeyPress += Validacion.NoSimbolos;
            txtDescripcion1.KeyPress += Validacion.NoNumeros;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento

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

            var marca = _MarcaServicio.ObtenerPorId(entidadId);

            // Datos Personales
            txtDescripcion1.Text = marca.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaMarca = new MarcaDto
            {
                Descripcion = txtDescripcion1.Text,
            };

            _MarcaServicio.Insertar(nuevaMarca);

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

            var MarcaParaModificar = new MarcaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion1.Text
            };

            _MarcaServicio.Modificar(MarcaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _MarcaServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
