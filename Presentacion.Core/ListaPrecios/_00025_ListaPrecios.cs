namespace Presentacion.Core.ListaPrecio
{
    using System.Windows.Forms;
    using Helpers;
    using ListaPrecios;
    using XCommerce.Servicio.Core.ListaPrecio.DTOs;
    using XCommerce.Servicio.Core.ListaPrecio;

    public partial class _00025_ListaPrecios : FormularioBase.FormularioConsulta
    {
        private readonly IListaPreciosServicio _listaPreciosServicio;
        public _00025_ListaPrecios() :this(new ListaPreciosServicio())
        {
            InitializeComponent();
        }

        public _00025_ListaPrecios(IListaPreciosServicio listaPreciosServicio)
        {
            _listaPreciosServicio = listaPreciosServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Rentabilidad"].Visible = true;
            grilla.Columns["Rentabilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Rentabilidad"].HeaderText = @"Rentabilidad";
            grilla.Columns["Rentabilidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            dgvGrilla.DataSource = _listaPreciosServicio.Obtener(string.Empty);
        }

        public override void EjecutarNuevo()
        {
            var fListaPrecio = new _00026_ABM_ListaPrecios(TipoOp.Nuevo, EntidadId);
            fListaPrecio.ShowDialog();
            ActualizarSegunOperacion(fListaPrecio.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((ListaPreciosDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fListaPrecio = new _00026_ABM_ListaPrecios(TipoOp.Modificar, EntidadId);
                fListaPrecio.ShowDialog();

                ActualizarSegunOperacion(fListaPrecio.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Lista de Precios se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((ListaPreciosDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fListaPrecio = new _00026_ABM_ListaPrecios(TipoOp.Eliminar, EntidadId);

                fListaPrecio.ShowDialog();

                ActualizarSegunOperacion(fListaPrecio.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Lista de Precios se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
