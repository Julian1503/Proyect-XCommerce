namespace Presentacion.Core.Banco
{
    using System.Windows.Forms;
    using Helpers;
    using XCommerce.Servicio.Core.Banco;
    using XCommerce.Servicio.Core.Banco.DTOs;

    public partial class _00021_Banco : FormularioBase.FormularioConsulta
    {
        private readonly IBancoServicio _bancoServicio;
        public _00021_Banco() : this(new BancoServicio())
        {
            InitializeComponent();
        }

        public _00021_Banco(IBancoServicio bancoServicio)
        {
            _bancoServicio = bancoServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _bancoServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fBanco = new _00022_ABM_Banco(TipoOp.Nuevo,EntidadId);
            fBanco.ShowDialog();
            ActualizarSegunOperacion(fBanco.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((BancoDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fBanco = new _00022_ABM_Banco(TipoOp.Modificar, EntidadId);
                fBanco.ShowDialog();

                ActualizarSegunOperacion(fBanco.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Banco se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((BancoDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fBanco = new _00022_ABM_Banco(TipoOp.Eliminar, EntidadId);

                fBanco.ShowDialog();

                ActualizarSegunOperacion(fBanco.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Banco se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
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
