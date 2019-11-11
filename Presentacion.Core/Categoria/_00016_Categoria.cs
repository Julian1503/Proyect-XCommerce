namespace Presentacion.Core.Categoria
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Categoria;
    using XCommerce.Servicio.Core.Categoria.DTOs;

    public partial class _00016_Categoria : FormularioConsulta
    {

        private readonly ICategoriaServicio _categoriaServicio;

        public _00016_Categoria()
            : this(new CategoriaServicio())
        {
            InitializeComponent();
        }

        public _00016_Categoria(ICategoriaServicio CategoriaServicio)
        {
            _categoriaServicio = CategoriaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Marca";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _categoriaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fCategoriaAbm = new _00017_Categoria_ABM(TipoOp.Nuevo);
            fCategoriaAbm.ShowDialog();

            ActualizarSegunOperacion(fCategoriaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((CategoriaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fCategoriaAbm = new _00017_Categoria_ABM(TipoOp.Modificar, EntidadId);
                fCategoriaAbm.ShowDialog();

                ActualizarSegunOperacion(fCategoriaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Marca se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((CategoriaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fCategoriaAbm = new _00017_Categoria_ABM(TipoOp.Eliminar, EntidadId);

                fCategoriaAbm.ShowDialog();

                ActualizarSegunOperacion(fCategoriaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Marca se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ======================================================================================= //

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
