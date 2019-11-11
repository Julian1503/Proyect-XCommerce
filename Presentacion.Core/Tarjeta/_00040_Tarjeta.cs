namespace Presentacion.Core.Tarjeta
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Tarjeta;
    using XCommerce.Servicio.Core.Tarjeta.DTOs;

    public partial class _00040_Tarjeta : FormularioConsulta
    {
        private readonly ITarjetaServicio _TarjetaServicio;

        public _00040_Tarjeta()
            : this(new TarjetaServicio())
        {
            InitializeComponent();
        }

        public _00040_Tarjeta(ITarjetaServicio TarjetaServicio)
        {
            _TarjetaServicio = TarjetaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Tarjeta";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _TarjetaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fTarjetaAbm = new _00041_ABM_Tarjeta(TipoOp.Nuevo);
            fTarjetaAbm.ShowDialog();

            ActualizarSegunOperacion(fTarjetaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((TarjetaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fTarjetaAbm = new _00041_ABM_Tarjeta(TipoOp.Modificar, EntidadId);
                fTarjetaAbm.ShowDialog();

                ActualizarSegunOperacion(fTarjetaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Tarjeta se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((TarjetaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fTarjetaAbm = new _00041_ABM_Tarjeta(TipoOp.Eliminar, EntidadId);

                fTarjetaAbm.ShowDialog();

                ActualizarSegunOperacion(fTarjetaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La tarjeta se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
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
