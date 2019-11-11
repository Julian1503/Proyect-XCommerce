
namespace Presentacion.Core.Caja
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Caja;
    using XCommerce.Servicio.Core.Caja.DTOs;
    using XCommerce.Servicio.Core.CompranteMesa;
    using XCommerce.Servicio.Core.DetalleCaja;
    using XCommerce.Servicio.Core.Entidad;
    using XCommerce.Servicio.Core.Movimiento;

    public partial class _10008_CerrarCaja : FormularioBase.FormularioBase
    {
        private readonly IComprobanteMesaServicio _comprobanteServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly ICajaServicio _cajaServicio;
        private decimal _total { get; set; }

        public _10008_CerrarCaja() : this (new ComprobanteMesaServicio(), new CajaServicio(),new MovimientoServicio())
        {
            InitializeComponent();
            menuAccesoRapido.BackColor = Constantes.Color.ColorMenu;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
            btnCerrarCaja.Image = Constantes.ImagenesSistema.Caja;
        }

        public _10008_CerrarCaja(IComprobanteMesaServicio comprobanteServicio, ICajaServicio cajaServicio, IMovimientoServicio movimientoServicio)
        {
            _movimientoServicio = movimientoServicio;
            _cajaServicio = cajaServicio;
            _comprobanteServicio = comprobanteServicio;
        }

        private void _10008_CerrarCaja_Load(object sender, EventArgs e)
        {
            var caja = _cajaServicio.ObtenerCajaAbierta();
            //var det = _movimientoServicio.ObtenerPorCaja(Entidad.CajaId);
            var det = _cajaServicio.ObtenerPorDetallesId(Entidad.CajaId);
            //_total = det.Where(x=>x.TipoMovimento==XCommerce.AccesoDatos.TipoMovimiento.Ingreso).Sum(x => x.Monto)- det.Where(x => x.TipoMovimento == XCommerce.AccesoDatos.TipoMovimiento.Egreso).Sum(x => x.Monto)+caja.MontoApertura;
            _total = det.Sum(x=>x.Monto);
            txtMontoSistema.Text = _total.ToString("C");
            dgvGrilla.DataSource = det;
            Formatear();
        }

        private void Formatear()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            dgvGrilla.Columns["Monto"].Visible = true;
            dgvGrilla.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Monto"].HeaderText = @"Monto";
            dgvGrilla.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["TipoPagoStr"].Visible = true;
            dgvGrilla.Columns["TipoPagoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["TipoPagoStr"].HeaderText = @"Tipo pago";
            dgvGrilla.Columns["TipoPagoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvGrilla.Columns["Descripcion"].Visible = true;
            //dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            //dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvGrilla.Columns["TipoMovimientoStr"].Visible = true;
            //dgvGrilla.Columns["TipoMovimientoStr"].Width = 150;
            //dgvGrilla.Columns["TipoMovimientoStr"].HeaderText = @"Tipo Movimiento";
            //dgvGrilla.Columns["TipoMovimientoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvGrilla.Columns["Fecha"].Visible = true;
            //dgvGrilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvGrilla.Columns["Fecha"].HeaderText = @"Fecha";
            //dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvGrilla.Columns["Monto"].Visible = true;
            //dgvGrilla.Columns["Monto"].Width = 100;
            //dgvGrilla.Columns["Monto"].HeaderText = @"Monto";
            //dgvGrilla.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"¿Esta seguro de cerrar la caja?", "Cerrando Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                if(_comprobanteServicio.ComprobantesCerrados())
                {
                    var caja = _cajaServicio.ObtenerCajaAbierta();
                    var cajita = new CajaDto
                    {
                        Id = caja.Id,
                        FechaCierre = DateTime.Now,
                        FechaApertura = caja.FechaApertura,
                        MontoCierre = nudMontoCierre.Value,
                        MontoApertura = caja.MontoApertura,
                        MontoSistema = _total,
                        UsuarioCierreId = Entidad.UsuarioId,
                        UsuarioAperturaId = caja.UsuarioAperturaId
                    };
                    _cajaServicio.Cerrar(cajita);
                    MessageBox.Show("Se cerro corretamente la caja", "Cierre de Caja", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    Entidad.CajaAbierta = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Finalice las ventas del salon antes de cerrar caja");
                }
            }
        }

        private void nudMontoCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtDiferencia.Text = (nudMontoCierre.Value - _total).ToString("C");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
