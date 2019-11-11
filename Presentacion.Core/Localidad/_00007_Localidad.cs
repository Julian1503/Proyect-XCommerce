namespace Presentacion.Core.Localidad
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Localidad;
    using XCommerce.Servicio.Core.Localidad.DTOs;

    public partial class _00007_Localidad : FormularioConsulta
    {
        private readonly ILocalidadServicio _localidadServicio;

        public _00007_Localidad()
            : this(new LocalidadServicio())
        {
            InitializeComponent();
        }

        public _00007_Localidad(ILocalidadServicio localidadServicio)
        {
            _localidadServicio = localidadServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Localidad";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Provincia"].Visible = true;
            grilla.Columns["Provincia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Provincia"].HeaderText = @"Provincia";
            grilla.Columns["Provincia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _localidadServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new _00008_Localidad_ABM(TipoOp.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((LocalidadDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00008_Localidad_ABM(TipoOp.Modificar, EntidadId);
                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La localidad se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((LocalidadDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00008_Localidad_ABM(TipoOp.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La localidad se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
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
