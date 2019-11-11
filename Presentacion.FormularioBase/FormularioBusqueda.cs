namespace Presentacion.FormularioBase
{
    using System;
    using System.Windows.Forms;

    public partial class FormularioBusqueda : FormularioBase
    {
        public object EntidadSeleccionada;

        public bool RealizoOperacion { get; set; }

        public FormularioBusqueda()
        {
            InitializeComponent();
            toolStrip1.BackColor = Constantes.Color.ColorMenu;
            RealizoOperacion = false;
            btnSeleccionar.Image = Constantes.ImagenesSistema.Seleccionar;
            btnActualizar.Image = Constantes.ImagenesSistema.Actualizar;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,txtBuscar.Text);
        }

        protected virtual void ActualizarDatos(DataGridView grilla, string cadena)
        {
            
        }

        public virtual void btnSeleccionar_Click(object sender, EventArgs e)
        {
           
        }

        protected void AgregarBotones(ToolStripButton control)
        {
            toolStrip1.Items.Add(control);
        }

        private void FormularioBusqueda_Load(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,string.Empty);
            FormatearGrilla(dgvGrilla);
        }

        protected virtual void FormatearGrilla(DataGridView dgvGrilla)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }
        }
        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,string.Empty);
        }
    }
}
