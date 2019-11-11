namespace Presentacion.Core.Cliente
{
    using System;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Cliente;
    using XCommerce.Servicio.Core.Cliente.DTOs;

    public partial class _10007_BuscarPorCtaCte : FormularioBase.FormularioBusqueda
    {
        public ClienteDto Cliente;
        public bool RealizoOperacion { get; private set; }
        private readonly IClienteServicio _clienteServicio;
        public _10007_BuscarPorCtaCte() 
        {
            InitializeComponent();
            _clienteServicio = new ClienteServicio();
            RealizoOperacion = false;
            Cliente = new ClienteDto();
        }
        

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);
            dgvGrilla.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].Width = 100;
            dgvGrilla.Columns["Dni"].HeaderText = @"DNI";
            dgvGrilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Celular"].Visible = true;
            dgvGrilla.Columns["Celular"].Width = 150;
            dgvGrilla.Columns["Celular"].HeaderText = @"Celular";
            dgvGrilla.Columns["Sobregiro"].Visible = true;
            dgvGrilla.Columns["Sobregiro"].Width = 150;
            dgvGrilla.Columns["Sobregiro"].HeaderText = @"Sobregiro";

        }

        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("Seleccion una fila");
                return;
            }
            Cliente.Apellido = ((ClienteDto)EntidadSeleccionada).Apellido;
                Cliente.Nombre = ((ClienteDto)EntidadSeleccionada).Nombre;
                Cliente.Id = ((ClienteDto)EntidadSeleccionada).Id;
                Cliente.Dni = ((ClienteDto)EntidadSeleccionada).Dni;

                RealizoOperacion = true;
                this.Close();
        }

        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _clienteServicio.ObtenerPorCtaCte(cadena);
        }
    }
}
