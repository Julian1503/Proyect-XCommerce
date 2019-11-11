namespace Presentacion.Core.Rubro
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Rubro;
    using XCommerce.Servicio.Core.Rubro.DTOs;

    public partial class _00018_Rubro : FormularioConsulta
    {
        private readonly IRubroServicio _RubroServicio;

        public _00018_Rubro()
            : this(new RubroServicio())
        {
            InitializeComponent();
        }

        public _00018_Rubro(IRubroServicio RubroServicio)
        {
            _RubroServicio = RubroServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Rubro";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _RubroServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fRubroAbm = new _00019_Rubro_ABM(TipoOp.Nuevo);
            fRubroAbm.ShowDialog();

            ActualizarSegunOperacion(fRubroAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fRubroAbm = new _00019_Rubro_ABM(TipoOp.Modificar, EntidadId);
                fRubroAbm.ShowDialog();

                ActualizarSegunOperacion(fRubroAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Rubro se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fRubroAbm = new _00019_Rubro_ABM(TipoOp.Eliminar, EntidadId);

                fRubroAbm.ShowDialog();

                ActualizarSegunOperacion(fRubroAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Rubro se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
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
