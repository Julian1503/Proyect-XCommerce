namespace Presentacion.Core.ListaPrecios
{
    using System.Windows.Forms;
    using Helpers;
    using XCommerce.Servicio.Core.ListaPrecio;
    using XCommerce.Servicio.Core.ListaPrecio.DTOs;

    public partial class _00026_ABM_ListaPrecios : FormularioBase.FormularioAbm
    {
        private readonly IListaPreciosServicio _listaPreciosServicio;
        public _00026_ABM_ListaPrecios(TipoOp operacion, long? entidadId = null) : base(operacion, entidadId)
        {
            InitializeComponent();
            _listaPreciosServicio = new ListaPreciosServicio();
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            if (operacion == TipoOp.Modificar ||
               operacion == TipoOp.Eliminar)
                CargarDatos(entidadId);

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(nudRentabilidad, "Rentabilidad");


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

            var listaPrecios = _listaPreciosServicio.ObtenerPorId(entidadId);
            txtDescripcion.Text = listaPrecios.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (nudRentabilidad.Value == 0)
            {
                if (MessageBox.Show(
                        "Esta por guardar una lista de precios con rentabilidad 0, ¿Esta seguro de hacerlo?",
                        "CUIDADO!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.No)
                    return false;
            }

            var listaPrecios = new ListaPreciosDto
            {
                Descripcion = txtDescripcion.Text,
                Rentabilidad = nudRentabilidad.Value
            };
            _listaPreciosServicio.Agregar(listaPrecios);
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
            if(nudRentabilidad.Value == 0)
            {
                if (MessageBox.Show(
                        "Esta por guardar una lista de precios con rentabilidad 0, ¿Esta seguro de hacerlo?",
                        "CUIDADO!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.No)
                    return false;
            }

            var listaPrecios = new ListaPreciosDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Rentabilidad = nudRentabilidad.Value
            };
            _listaPreciosServicio.Modificar(listaPrecios);
            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;
            _listaPreciosServicio.Eliminar(EntidadId);
            return true;
        }
    }
}
