namespace Presentacion.Core.Cliente
{
    using System;
    using System.Windows.Forms;
    using CuentaCorriente;
    using FormularioBase;
    using XCommerce.Servicio.Core.CuentaCorriente;
    using XCommerce.Servicio.Core.CuentaCorriente.DTOs;

    public partial class _10009_CtaCte : FormularioBusqueda
    {
        private readonly ICuentaCorrienteServicio _cuentaCorriente;
        public _10009_CtaCte() :this(new CuentaCorrienteServicio())
        {
            InitializeComponent();
        }

        public _10009_CtaCte(ICuentaCorrienteServicio cuentaCorriente)
        {
            _cuentaCorriente = cuentaCorriente;
        }
        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _cuentaCorriente.Obtener(cadena);
        }

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            
            base.FormatearGrilla(dgvGrilla);
            dgvGrilla.Columns["NumeroCuenta"].Visible = true;
            dgvGrilla.Columns["NumeroCuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["NumeroCuenta"].HeaderText = @"N° de Cuenta";
            dgvGrilla.Columns["NumeroCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["ApyNomCliente"].Visible = true;
            dgvGrilla.Columns["ApyNomCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNomCliente"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNomCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["DniCliente"].Visible = true;
            dgvGrilla.Columns["DniCliente"].Width = 100;
            dgvGrilla.Columns["DniCliente"].HeaderText = @"DNI";
            dgvGrilla.Columns["DniCliente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Saldo"].Visible = true;
            dgvGrilla.Columns["Saldo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Saldo"].HeaderText = @"Saldo";
            dgvGrilla.Columns["Saldo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Limite"].Visible = true;
            dgvGrilla.Columns["Limite"].Width = 100;
            dgvGrilla.Columns["Limite"].HeaderText = @"Limite";
            dgvGrilla.Columns["Limite"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 100;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = @"Esta Eliminado";
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(EntidadSeleccionada == null)
            {
                MessageBox.Show("No selecciono un cliente");
                return;
            }
            if(!((CuentaCorrienteDto)EntidadSeleccionada).EstaEliminado)
            {
                var fPago = new _10011_PAgoCtaCte(((CuentaCorrienteDto) EntidadSeleccionada).ClienteId);
                fPago.ShowDialog();
                if (fPago.RealizoOperacion)
                {
                    ActualizarDatos(dgvGrilla, string.Empty);
                }
            }
            else
            {
                MessageBox.Show("La cuenta corriente esta Eliminada","Atencion");
            }
        }
    }
}
