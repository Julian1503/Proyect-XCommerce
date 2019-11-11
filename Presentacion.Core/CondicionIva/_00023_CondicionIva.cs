namespace Presentacion.Core.CondicionIva
{
    using System.Windows.Forms;
    using Helpers;
    using XCommerce.Servicio.Core.CondicionIva;
    using XCommerce.Servicio.Core.CondicionIva.DTOs;

    public partial class _00023_CondicionIva : FormularioBase.FormularioConsulta
    {
        private readonly ICondicionIvaServicio _condicionIvaServicio;
        public _00023_CondicionIva():this(new CondicionIvaServicio())
        {
            InitializeComponent();
        }

        public _00023_CondicionIva(ICondicionIvaServicio condicionIvaServicio)
        {
            _condicionIvaServicio = condicionIvaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            dgvGrilla.DataSource = _condicionIvaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fCondicionIva = new _00024_ABM_CondicionIva(TipoOp.Nuevo,EntidadId);
            fCondicionIva.ShowDialog();
            ActualizarSegunOperacion(fCondicionIva.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((CondicionIvaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fCondicionIva = new _00024_ABM_CondicionIva(TipoOp.Modificar, EntidadId);
                fCondicionIva.ShowDialog();

                ActualizarSegunOperacion(fCondicionIva.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Condicion de Iva se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((CondicionIvaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fCondicionIva = new _00024_ABM_CondicionIva(TipoOp.Eliminar, EntidadId);

                fCondicionIva.ShowDialog();

                ActualizarSegunOperacion(fCondicionIva.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La Condicion de Iva se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
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
