namespace Presentacion.Core.Tarjeta
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Tarjeta;
    using XCommerce.Servicio.Core.Tarjeta.DTOs;

    public partial class _00041_ABM_Tarjeta : FormularioAbm
    {
        
        private readonly ITarjetaServicio _tarjetaServicio;

        public _00041_ABM_Tarjeta(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _tarjetaServicio = new TarjetaServicio();
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

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

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

            var tarjeta = _tarjetaServicio.ObtenerPorId(entidadId.Value); 

            // Datos Personales
            txtDescripcion.Text = tarjeta.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaTarjeta = new TarjetaDto
            {
                Descripcion = txtDescripcion.Text,
            };

            _tarjetaServicio.Agregar(nuevaTarjeta);

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

            var tarjetaParaModificar = new TarjetaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _tarjetaServicio.Modificar(tarjetaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _tarjetaServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
