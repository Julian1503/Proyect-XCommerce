using Presentacion.Core.Kiosco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.ComprobanteKiosco.DTOs;
using XCommerce.Servicio.Core.CuentaCorriente;
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.DetalleCaja;
using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.FormaPago.DTOs;
using XCommerce.Servicio.Core.Kiosco;
using XCommerce.Servicio.Core.Movimiento;

namespace Presentacion.Core.FormaPago
{
    public partial class FormaPagoKiosco : FormularioPagoBase
    {
        private readonly IKioscoServicio _kioscoServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private readonly IFormaPago _formaPagoServicio;
        public bool Realizo;
        private ComprobanteKioscoDto  _comprobante;
        private decimal _pago1;
        private decimal _pago2;


        public FormaPagoKiosco()
        {
            InitializeComponent();
            btnCuentaCorriente.Enabled = false;
            btnTarjeta.Enabled = false;
            btnCheque.Enabled = false;
        }
        public FormaPagoKiosco(ICuentaCorrienteServicio cuentaCorrienteServicio,
            IFormaPago formaPagoServicio, IDetalleCajaServicio detalleCajaServicio, IKioscoServicio kioscoServicio) : this()
        {
            _formaPagoServicio = formaPagoServicio;
            _detalleCajaServicio = detalleCajaServicio;
            _kioscoServicio = kioscoServicio;
            _cuentaCorrienteServicio = cuentaCorrienteServicio;
            _pago1 = 0;
            _pago2 = 0;
        }
        public FormaPagoKiosco(ComprobanteKioscoDto comprobante) : this(new CuentaCorrienteServicio(), new FormaPagoServicio(), new DetalleCajaServicio(), new KioscoServicio())
        {
            _comprobante = comprobante;
            SetTotal(_comprobante.Total);
        }
        protected override void FinalizacionDelPago(string primerPago, string segundoPago, Panel pnlPago1, Panel pnlPago2)
        {
            base.FinalizacionDelPago(primerPago, segundoPago, pnlPago1, pnlPago2);
           
             _pago1 = ((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value;
             
             _comprobante.TipoComprobante = _tipoComprobante;
             var id = _kioscoServicio.CerrarKiosco(_comprobante,_comprobante.TipoComprobante);
             _detalleCajaServicio.Generar(_pago1, TipoPago.Efectivo);
             _formaPagoServicio.Agregar(new FormaPagoEfectivoDto
             {
                 TipoFormaPago = TipoFormaPago.Efectivo,
                 Monto = _pago1,
                 ComprobanteId = id
             });
            Realizo = true;
            Notificacion.NotificacionCorrecta.MensajeSatisfactorio("Compra satisfactoria");
            if(MessageBox.Show("¿Desea imprimir el comprobante?", "Imprimir", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                var fComprobante = new ComprobanteKiosco(id);
                fComprobante.ShowDialog();
            }
                this.Close();
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            btnEfectivo.Enabled = false;

        }
    }
}
