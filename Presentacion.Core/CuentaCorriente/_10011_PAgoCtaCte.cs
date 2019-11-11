using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.FormaPago.DTOs;

namespace Presentacion.Core.CuentaCorriente
{
    using System;
    using System.Windows.Forms;
    using VentasSalon;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.CuentaCorriente;
    using XCommerce.Servicio.Core.DetalleCaja;
    using XCommerce.Servicio.Core.Operacion;

    public partial class _10011_PAgoCtaCte : FormularioBase.FormularioBase
    {
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private readonly IOperacionServicio _operacionServicio;
        private readonly IDetalleCajaServicio _cajaServicio;
        private long _clienteId;
        private decimal _saldo;
        public object EntidadSeleccionada;

        public bool RealizoOperacion { get; set; }

        public _10011_PAgoCtaCte() :this(new OperacionServicio(), new DetalleCajaServicio(), new CuentaCorrienteServicio())
        {
            InitializeComponent();
            btnDetalles.Enabled = false;

        }

        public _10011_PAgoCtaCte(long clienteId):this()
        {
            _clienteId = clienteId;
            var cliente = _cuentaCorrienteServicio.ObtenerCorrientePorClienteId(_clienteId);
            this.Text +=$" {cliente.ApyNomCliente}";
            _saldo = cliente.Saldo;
            txtSaldo.Text = _saldo.ToString("C");
            nudMonto.Maximum = _saldo;
        }

        public _10011_PAgoCtaCte(IOperacionServicio operacionServicio,IDetalleCajaServicio cajaServicio, ICuentaCorrienteServicio cuentaCorrienteServicio)
        {
            _operacionServicio = operacionServicio;
            _cajaServicio = cajaServicio;
            _cuentaCorrienteServicio = cuentaCorrienteServicio;
            RealizoOperacion = false;
        }

        private void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource =
                _operacionServicio.Obtener(_cuentaCorrienteServicio.ObtenerCorrientePorClienteId(_clienteId).Id);

        }
        

        private void FormatearGrilla()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Fecha"].HeaderText = @"Fecha";
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["TipoOperacionStr"].Visible = true;
            dgvGrilla.Columns["TipoOperacionStr"].Width = 100;
            dgvGrilla.Columns["TipoOperacionStr"].HeaderText = @"Operacion";
            dgvGrilla.Columns["TipoOperacionStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Monto"].Visible = true;
            dgvGrilla.Columns["Monto"].Width = 100;
            dgvGrilla.Columns["Monto"].HeaderText = @"Monto";
            dgvGrilla.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Saldo"].Visible = true;
            dgvGrilla.Columns["Saldo"].Width = 100;
            dgvGrilla.Columns["Saldo"].HeaderText = @"Saldo";
            dgvGrilla.Columns["Saldo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        private bool HayDatos()
        {
            return dgvGrilla.RowCount > 0;
        }

        private void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatos())
            {
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
                if (((OperacionDto) EntidadSeleccionada).ComprobanteId != 0)
                {
                    btnDetalles.Enabled = true;
                }
                else
                {
                    btnDetalles.Enabled = false;
                }
            }
            else
            {
                EntidadSeleccionada = null;
            }
        }

        private void _10011_PAgoCtaCte_Load(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,string.Empty);
            FormatearGrilla();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("No hay comprobantes que detallar!", "Cuidado");
                return;
            }
            var fDet = new _10013_DetalleComprobante(((OperacionDto)EntidadSeleccionada).ComprobanteId);
            fDet.ShowDialog();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (_saldo > 0 && nudMonto.Value<=_saldo)
            {
                if(nudMonto.Value>0)
                {
                    _cuentaCorrienteServicio.Pagar(_clienteId, nudMonto.Value);
                    _cajaServicio.Generar(nudMonto.Value, TipoPago.CtaCte);
                    _operacionServicio.Agregar(new OperacionDto
                    {
                        Monto = nudMonto.Value,
                        CuentaCorrienteId = _cuentaCorrienteServicio.ObtenerCorrientePorClienteId(_clienteId).Id,
                        Fecha = DateTime.Now,
                        TipoOperacion = TipoOperacion.Cobranza
                    });
                    MessageBox.Show("Se pago exitosamente", "Atencion");
                    _saldo -= nudMonto.Value;
                    nudMonto.Value = 0;
                    txtSaldo.Text = _saldo.ToString("C");
                    ActualizarDatos(dgvGrilla,string.Empty);
                    RealizoOperacion = true;
                }
                else
                {
                    MessageBox.Show("No se puede pagar $0", "Atencion", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No puede pagar mas que el valor del saldo", "Atencion");
            }
            
        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            if(_saldo>= nudMonto.Value)
            txtSaldo.Text = (_saldo - nudMonto.Value).ToString("C");
        }
    }
}
