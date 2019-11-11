namespace Presentacion.Core.Precio
{
    using System;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Precio;

    public partial class _00044_Precio : FormularioBase.FormularioBase
    {
        public object EntidadSeleccionada;
        private readonly IPrecioServicio _precioServicio;
        public _00044_Precio() : this(new PrecioServicio())
        {
            InitializeComponent();
            toolStrip1.BackColor = Constantes.Color.ColorMenu;
            btnActualizarPrecio.Image = Constantes.ImagenesSistema.ActualizarPrecio;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
        }

        public _00044_Precio(IPrecioServicio precioServicio)
        {
            _precioServicio = precioServicio;
        }

        private void ActualizarGrilla(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _precioServicio.Obtener(cadenaBuscar);
        }


        private void _00044_Precio_Load(object sender, EventArgs e)
        {
            ActualizarGrilla(string.Empty);
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            dgvGrilla.Columns["NombreLista"].Visible = true;
            dgvGrilla.Columns["NombreLista"].Width = 100;
            dgvGrilla.Columns["NombreLista"].HeaderText = @"Lista";
            dgvGrilla.Columns["NombreLista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["DescripcionArticulo"].Visible = true;
            dgvGrilla.Columns["DescripcionArticulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["DescripcionArticulo"].HeaderText = @"Nombre del Producto";
            dgvGrilla.Columns["DescripcionArticulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["PrecioCosto"].Visible = true;
            dgvGrilla.Columns["PrecioCosto"].Width = 100;
            dgvGrilla.Columns["PrecioCosto"].HeaderText = @"Precio Costo";
            dgvGrilla.Columns["PrecioCosto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["PrecioPublico"].Visible = true;
            dgvGrilla.Columns["PrecioPublico"].Width = 100; 
            dgvGrilla.Columns["PrecioPublico"].HeaderText = @"Precio Venta";
            dgvGrilla.Columns["PrecioPublico"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["FechaActualizacion"].Visible = true;
            dgvGrilla.Columns["FechaActualizacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["FechaActualizacion"].HeaderText = @"Fecha Actualizacion";
            dgvGrilla.Columns["FechaActualizacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["FechaActualizacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        private bool HayDatos()
        {
            return dgvGrilla.RowCount > 0;
        }

        public virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatos())
            {
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadSeleccionada = null;
            }
        }

        private void btnActualizarPrecio_Click(object sender, EventArgs e)
        {
            var fActualizarPrecio = new _10002_ActualizarPrecios();
            fActualizarPrecio.ShowDialog();
            if (fActualizarPrecio.RealizoOperacion)
            {
                ActualizarGrilla(string.Empty);
            }
        }
    }
}
