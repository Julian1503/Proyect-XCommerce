namespace Presentacion.Core.Banco
{
    using System.Windows.Forms;
    using Helpers;
    using XCommerce.Servicio.Core.Banco;
    using XCommerce.Servicio.Core.Banco.DTOs;

    public partial class _00022_ABM_Banco : FormularioBase.FormularioAbm
    {
        private readonly IBancoServicio _bancoServicio;
        public _00022_ABM_Banco(TipoOp operacion, long? entidadId = null):base(operacion,entidadId)
        {
            InitializeComponent();
            _bancoServicio=new BancoServicio();
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            if (operacion==TipoOp.Modificar ||
               operacion==TipoOp.Eliminar)
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

            var banco = _bancoServicio.ObtenerPorId(entidadId);
            txtDescripcion.Text = banco.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var banco = new BancoDto
            {
               Descripcion = txtDescripcion.Text
            };
            _bancoServicio.Agregar(banco);
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
            var banco = new BancoDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };
            _bancoServicio.Modificar(banco);
            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;
            _bancoServicio.Eliminar(EntidadId);
            return true;
        }
    }
}
