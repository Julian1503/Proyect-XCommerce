namespace Presentacion.Core.BajaArticulo
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.BajaArticulo;
    using XCommerce.Servicio.Core.BajaArticulo.DTOs;

    public partial class _00013_BajaArticulos : FormularioConsulta
    {
        private readonly IBajaArticuloServicio _bajaArticuloServicio;

        public _00013_BajaArticulos():this(new BajaArticuloServicio())
        {
            InitializeComponent();
        }

        public _00013_BajaArticulos(IBajaArticuloServicio bajaArticuloServicio)
        {
            _bajaArticuloServicio = bajaArticuloServicio;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            dgvGrilla.DataSource = _bajaArticuloServicio.Obtener(cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].Width = 100;
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Articulo"].Visible = true;
            dgvGrilla.Columns["Articulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Motivo"].Visible = true;
            dgvGrilla.Columns["Motivo"].Width = 100;
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].Width = 100;
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Observacion"].Visible = true;
            dgvGrilla.Columns["Observacion"].Width = 100;
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 100;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void EjecutarNuevo()
        {
            var fBajaNuevo = new _00014_ABM_BajaArticulo(TipoOp.Nuevo);
            fBajaNuevo.ShowDialog();
            ActualizarSegunOperacion(fBajaNuevo.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((BajaArticuloDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fBajaArticulo = new _00014_ABM_BajaArticulo(TipoOp.Modificar, EntidadId);
                fBajaArticulo.ShowDialog();

                ActualizarSegunOperacion(fBajaArticulo.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Baja de Articulos se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((BajaArticuloDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fBajaArticulo = new _00014_ABM_BajaArticulo(TipoOp.Eliminar, EntidadId);
                fBajaArticulo.ShowDialog();

                ActualizarSegunOperacion(fBajaArticulo.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Baja de Articulos se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla,string.Empty);
            }
        }
    }
}
