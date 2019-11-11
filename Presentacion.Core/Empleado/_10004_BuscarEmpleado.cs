namespace Presentacion.Core.Empleado
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Empleado;
    using XCommerce.Servicio.Core.Empleado.DTOs;
    using XCommerce.Servicio.Core.Entidad;

    public partial class _10004_BuscarEmpleado : FormularioBase.FormularioBusqueda
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        public long EmpleadoId { get;private set; }
        public string EmpleadoNombre { get; private set; }
        public string EmpleadoApellido { get; private set; }
        public int Legajo { get;  set; }

        private bool FlagDelivery;
        public _10004_BuscarEmpleado() : this(new EmpleadoServicio())
        {
            InitializeComponent();
        }

        public _10004_BuscarEmpleado(bool flagDelivery):this()
        {
            FlagDelivery = flagDelivery;
        }
        private _10004_BuscarEmpleado(IEmpleadoServicio empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }

        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            if (FlagDelivery)
            {
                grilla.DataSource = _empleadoServicio.ObtenerEmpleadosActuales(string.Empty,Entidad.CategoriaCadeteDescripcion);
                return;
            }
            grilla.DataSource = _empleadoServicio.ObtenerEmpleadosActuales(string.Empty, Entidad.CategoriaMozoDescripcion);
        }

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);
            dgvGrilla.Columns["Legajo"].Visible = true;
            dgvGrilla.Columns["Legajo"].Width = 100;
            dgvGrilla.Columns["Legajo"].HeaderText = @"Legajo";
            dgvGrilla.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].Width = 100;
            dgvGrilla.Columns["Dni"].HeaderText = @"DNI";
            dgvGrilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (FlagDelivery)
            {
                dgvGrilla.Columns["Pedidos"].Visible = true;
                dgvGrilla.Columns["Pedidos"].Width = 100;
                dgvGrilla.Columns["Pedidos"].HeaderText = @"Envios pendientes";
                dgvGrilla.Columns["Pedidos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("Seleccion una fila");
                return;
            }
            EmpleadoId = ((EmpleadoDto) EntidadSeleccionada).Id;
            EmpleadoNombre = ((EmpleadoDto)EntidadSeleccionada).Nombre;
            EmpleadoApellido = ((EmpleadoDto)EntidadSeleccionada).Apellido;
            Legajo = ((EmpleadoDto)EntidadSeleccionada).Legajo;
            RealizoOperacion = true;
            this.Close();

        }
    }
}
