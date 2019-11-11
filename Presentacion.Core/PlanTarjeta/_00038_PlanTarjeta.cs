namespace Presentacion.Core.PlanTarjeta
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.PlanTarjeta;
    using XCommerce.Servicio.Core.PlanTarjeta.DTOs;

    public partial class _00038_PlanTarjeta : FormularioConsulta
    {


        private readonly IPlanTarjetaServicio _PlanTarjetaServicio;

        public _00038_PlanTarjeta()
            : this(new PlanTarjetaServicio())
        {
            InitializeComponent();
        }

        public _00038_PlanTarjeta(IPlanTarjetaServicio PlanTarjetaServicio)
        {
            _PlanTarjetaServicio = PlanTarjetaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["TarjetaNombre"].Visible = true;
            grilla.Columns["TarjetaNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TarjetaNombre"].HeaderText = @"Tarjeta";
            grilla.Columns["TarjetaNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Alicuota"].Visible = true;
            grilla.Columns["Alicuota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Alicuota"].HeaderText = @"Alicuota";
            grilla.Columns["Alicuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _PlanTarjetaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fPlanTarjetaAbm = new _00039_ABM_PlanTarjeta(TipoOp.Nuevo);
            fPlanTarjetaAbm.ShowDialog();

            ActualizarSegunOperacion(fPlanTarjetaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (!((PlanTarjetaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fPlanTarjetaAbm = new _00039_ABM_PlanTarjeta(TipoOp.Modificar, EntidadId);
                fPlanTarjetaAbm.ShowDialog();

                ActualizarSegunOperacion(fPlanTarjetaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Plan Tarjeta se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((PlanTarjetaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fPlanTarjetaAbm = new _00039_ABM_PlanTarjeta(TipoOp.Eliminar, EntidadId);

                fPlanTarjetaAbm.ShowDialog();

                ActualizarSegunOperacion(fPlanTarjetaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Plan Tarjeta se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
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
