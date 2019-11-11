namespace Presentacion.Core.Reserva
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Reserva;
    using XCommerce.Servicio.Core.Reserva.DTOs;

    public partial class _00029_Reserva : FormularioConsulta
    {
        
        private readonly IReservaServicio _reservaServicio;

        public _00029_Reserva()
            : this(new ReservaServicio())
        {
            InitializeComponent();
        }

        public _00029_Reserva(IReservaServicio reservaServicio)
        {
            _reservaServicio = reservaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
          base.FormatearGrilla(grilla);
            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Senia"].Visible = true;
            grilla.Columns["Senia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Senia"].HeaderText = @"Seña";
            grilla.Columns["Senia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoReservaStr"].Visible = true;
            grilla.Columns["EstadoReservaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoReservaStr"].HeaderText = @"Estado";
            grilla.Columns["EstadoReservaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 100;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _reservaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fReservaAbm = new _00030_ABM_Reserva(TipoOp.Nuevo);
            fReservaAbm.ShowDialog();

            ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((ReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fReservaAbm = new _00030_ABM_Reserva(TipoOp.Modificar, EntidadId);
                fReservaAbm.ShowDialog();

                ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Reserva se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((ReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fReservaAbm = new _00030_ABM_Reserva(TipoOp.Eliminar, EntidadId);

                fReservaAbm.ShowDialog();

                ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Reserva se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
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
