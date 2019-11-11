namespace Presentacion.Core.MotivoReserva
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.MotivoReserva;
    using XCommerce.Servicio.Core.MotivoReserva.DTOs;

    public partial class _00033_MotivoReserva : FormularioConsulta
    {
        

        private readonly IMotivoReservaServicio _motivoReservaServicio;

        public _00033_MotivoReserva()
            : this(new MotivoReservaServicio())
        {
            InitializeComponent();
        }

        public _00033_MotivoReserva(IMotivoReservaServicio motivoReservaServicio)
        {
            _motivoReservaServicio = motivoReservaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Motivo Reserva";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _motivoReservaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new _00034_ABM_MotivoReserva(TipoOp.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }
        public override void EjecutarModificar()
        {
            if (!((MotivoReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fmotivoReservaAbm = new  _00034_ABM_MotivoReserva(TipoOp.Modificar, EntidadId);
                fmotivoReservaAbm.ShowDialog();

                ActualizarSegunOperacion(fmotivoReservaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Motivo de Reserva se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((MotivoReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00034_ABM_MotivoReserva(TipoOp.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Motivo de Reserva se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
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
