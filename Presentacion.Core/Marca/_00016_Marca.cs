namespace Presentacion.Core.Marca
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Marca;
    using XCommerce.Servicio.Core.Marca.DTOs;

    public partial class _00016_Marca : FormularioConsulta
    {

        private readonly IMarcaServicio _MarcaServicio;

        public _00016_Marca()
            : this(new MarcaServicio())
        {
            InitializeComponent();
        }

        public _00016_Marca(IMarcaServicio MarcaServicio)
        {
            _MarcaServicio = MarcaServicio;
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
            grilla.DataSource = _MarcaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fMarcaAbm = new _00017_Marca_ABM(TipoOp.Nuevo);
            fMarcaAbm.ShowDialog();

            ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((MarcaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fMarcaAbm = new _00017_Marca_ABM(TipoOp.Modificar, EntidadId);
                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
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

            if (!((MarcaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fMarcaAbm = new _00017_Marca_ABM(TipoOp.Eliminar, EntidadId);

                fMarcaAbm.ShowDialog();

                ActualizarSegunOperacion(fMarcaAbm.RealizoAlgunaOperacion);
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
