namespace Presentacion.Core.MotivoBaja
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.MotivoBaja;
    using XCommerce.Servicio.Core.MotivoBaja.DTOs;


    public partial class _00011_MotivoBaja : FormularioConsulta
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;

        public _00011_MotivoBaja():this(new MotivoBajaServicio())
        {
            InitializeComponent();
        }
        public _00011_MotivoBaja(IMotivoBajaServicio _bajaServicio)
        {
            _motivoBajaServicio = _bajaServicio;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            dgvGrilla.DataSource = _motivoBajaServicio.Obtener(cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 100;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((MotivoBajaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fMotivoNuevo = new _00012_ABM_MotivoBaja(TipoOp.Modificar, EntidadId);
            fMotivoNuevo.ShowDialog();
            ActualizarSegunOperacion(fMotivoNuevo.RealizoAlgunaOperacion);
            }

            else
            {
                MessageBox.Show(@"El Motivo de Baja se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((MotivoBajaDto) EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fMotivoEliminar = new _00012_ABM_MotivoBaja(TipoOp.Eliminar,EntidadId);
                fMotivoEliminar.ShowDialog();
                ActualizarSegunOperacion(fMotivoEliminar.RealizoAlgunaOperacion);
            }

            else
            {
                MessageBox.Show(@"El Motivo de Baja se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarNuevo()
        {
            
                var fMotivoNuevo = new _00012_ABM_MotivoBaja(TipoOp.Nuevo);
                fMotivoNuevo.ShowDialog();
                ActualizarSegunOperacion(fMotivoNuevo.RealizoAlgunaOperacion);
           

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
