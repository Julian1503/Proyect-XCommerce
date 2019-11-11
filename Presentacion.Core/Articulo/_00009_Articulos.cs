namespace Presentacion.Core.Articulo
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;

    public partial class _00009_Articulos : FormularioConsulta
    {
        private readonly IArticuloServicio _articuloServicio;

        public _00009_Articulos() : this(new ArticuloServicio())
        {
            InitializeComponent();
        }
        public _00009_Articulos(IArticuloServicio articuloServicio) 
        {
            _articuloServicio = articuloServicio;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _articuloServicio.Obtener(cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 100;
            dgvGrilla.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["CodigoBarra"].Visible = true;
            dgvGrilla.Columns["CodigoBarra"].Width = 100;
            dgvGrilla.Columns["CodigoBarra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Abreviatura"].Visible = true;
            dgvGrilla.Columns["Abreviatura"].Width = 100;
            dgvGrilla.Columns["Abreviatura"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Stock"].Visible = true;
            dgvGrilla.Columns["Stock"].Width = 100;
            dgvGrilla.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void EjecutarLoadFormulario()
        {
            base.EjecutarLoadFormulario();
        }

        public override void EjecutarNuevo()
        {
            var fArticuloNuevo = new _00010_ABM_Articulo(TipoOp.Nuevo);
            fArticuloNuevo.ShowDialog();
            ActualizarSegunOperacion(fArticuloNuevo.RealizoAlgunaOperacion);
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue){ MessageBox.Show(@"¡La grilla esta vacia!",@"Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); return;}
            if (!((ArticuloDto) EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if(!PuedeEjecutarComando) return;


                var fArticuloEliminar = new _00010_ABM_Articulo(TipoOp.Eliminar,EntidadId);
                fArticuloEliminar.ShowDialog();
                ActualizarSegunOperacion(fArticuloEliminar.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Articulo se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
           
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue){ MessageBox.Show("¡La grilla esta vacia!","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); return;}

            if (!((ArticuloDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;


                var fArticuloModificar = new _00010_ABM_Articulo(TipoOp.Modificar, EntidadId);
                fArticuloModificar.ShowDialog();
                ActualizarSegunOperacion(fArticuloModificar.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Articulo se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
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
