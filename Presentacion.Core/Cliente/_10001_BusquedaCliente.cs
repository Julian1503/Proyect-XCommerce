namespace Presentacion.Core.Cliente
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using XCommerce.Servicio.Core.Cliente;
    using XCommerce.Servicio.Core.Cliente.DTOs;

    public partial class _10001_BusquedaCliente : FormularioBusqueda
    {
        private readonly IClienteServicio _clienteServicio;
        public long ClienteId { get; protected set; }
        public _10001_BusquedaCliente() : this(new ClienteServicio())
        {
            InitializeComponent();
        }
        public _10001_BusquedaCliente(IClienteServicio  clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }
        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _clienteServicio.Obtener(cadena);
        }

        protected override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);
            grilla.Columns["ApyNom"].Visible = true;
            grilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            grilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].Width = 100;
            grilla.Columns["Dni"].HeaderText = @"DNI";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Celular"].Visible = true;
            grilla.Columns["Celular"].Width = 150;
            grilla.Columns["Celular"].HeaderText = @"Celular";
            grilla.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("Seleccion una fila");
                return;
            }
            if (EntidadSeleccionada == null) MessageBox.Show("Seleccion una fila");
            ClienteId = ((ClienteDto) EntidadSeleccionada).Id;
            RealizoOperacion = true;

            this.Close();
        }
    }
}
