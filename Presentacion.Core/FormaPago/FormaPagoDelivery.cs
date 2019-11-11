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
using XCommerce.Servicio.Core.CompranteMesa;
using XCommerce.Servicio.Core.CuentaCorriente;
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.Delivery.DTOs;
using XCommerce.Servicio.Core.DetalleCaja;
using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.FormaPago.DTOs;
using XCommerce.Servicio.Core.Movimiento;
using XCommerce.Servicio.Core.PlanTarjeta.DTOs;

namespace Presentacion.Core.FormaPago
{
    public partial class FormaPagoDelivery : FormularioPagoBase
    {
        private readonly IDeliveryServicio _deliveryServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private readonly IFormaPago _formaPagoServicio;
        public bool Realizo;
        private DeliveryDto _comprobante;
        private decimal _pago1;
        private decimal _pago2;
        public FormaPagoDelivery() : base()
        {
            InitializeComponent();
            btnCheque.Enabled = false;
        }
        public FormaPagoDelivery(ICuentaCorrienteServicio cuentaCorrienteServicio,
            IFormaPago formaPagoServicio, IDetalleCajaServicio detalleCajaServicio, IDeliveryServicio deliveryServicio) : this()
        {
            _formaPagoServicio = formaPagoServicio;
            _detalleCajaServicio = detalleCajaServicio;
            _deliveryServicio = deliveryServicio;
            _cuentaCorrienteServicio = cuentaCorrienteServicio;
            _pago1 = 0;
            _pago2 = 0;
        }
        public FormaPagoDelivery(long comprobanteId) : this(new CuentaCorrienteServicio(), new FormaPagoServicio(), new DetalleCajaServicio(), new DeliveryServicio())
        {
            _comprobante = _deliveryServicio.ObtenerPorId(comprobanteId);
            SetTotal(_comprobante.Total);
        }

        protected override void FinalizacionDelPago(string primerPago, string segundoPago, Panel pnlPago1, Panel pnlPago2)
        {
            base.FinalizacionDelPago(primerPago, segundoPago, pnlPago1, pnlPago2);
            if (!primerPago.Equals(""))
            {
                _pago1 = ((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value;
                switch (primerPago)
                {
                    case "efectivo":
                        _pago1 = ((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value - _vuelto;
                        _vuelto -= _vuelto;
                        _detalleCajaServicio.Generar(_pago1, TipoPago.Efectivo);
                        _formaPagoServicio.Agregar(new FormaPagoEfectivoDto
                        {
                            TipoFormaPago = TipoFormaPago.Efectivo,
                            Monto = _pago1,
                            ComprobanteId = _comprobante.Id
                        });
                        _comprobante.MontoEfectivo += _pago1;
                        break;
                    case "tarjeta":
                        _detalleCajaServicio.Generar(_pago1, TipoPago.Tarjeta);
                        _formaPagoServicio.Agregar(new FormaPagoTarjetaDto
                        {
                            TipoFormaPago = TipoFormaPago.Tarjeta,
                            ComprobanteId = _comprobante.Id,
                            Monto = _pago1,
                            NumeroTarjeta = ((TextBox)pnlPago1.Controls["txtNumeroTarjeta"]).Text,
                            PlanTarjetaId = ((PlanTarjetaDto)((ComboBox)pnlPago1.Controls["cmbPlanDeTarjeta"]).SelectedItem).Id,
                            Numero = ((TextBox)pnlPago1.Controls["txtCodigo"]).Text,
                            Cupon = ""
                        });
                        _comprobante.MontoTarjeta += _pago1;
                        break;
                    case "cuenta corriente":
                        _detalleCajaServicio.Generar(_pago1, TipoPago.CtaCte);
                        _formaPagoServicio.Agregar(new FormaPagoCtaCteDto
                        {
                            TipoFormaPago = TipoFormaPago.CuentaCorriente,
                            Monto = _pago1,
                            ComprobanteId = _comprobante.Id,
                            ClienteId = _clienteId
                        });
                        _comprobante.MontoCtaCte += _pago1;
                        break;
                }
            }
            if (!segundoPago.Equals(""))
            {
                _pago2 = ((NumericUpDown)pnlPago2.Controls["nudMonto"]).Value;
                switch (segundoPago)
                {
                    case "efectivo":
                        _pago2 = ((NumericUpDown)pnlPago2.Controls["nudMonto"]).Value - _vuelto;
                        _vuelto -= _vuelto;
                        _detalleCajaServicio.Generar(_pago2, TipoPago.Efectivo);
                        _formaPagoServicio.Agregar(new FormaPagoEfectivoDto
                        {
                            TipoFormaPago = TipoFormaPago.Efectivo,
                            Monto = _pago2,
                            ComprobanteId = _comprobante.Id
                        });
                        _comprobante.MontoEfectivo += _pago2;
                        break;
                    case "tarjeta":
                        _formaPagoServicio.Agregar(new FormaPagoTarjetaDto
                        {
                            TipoFormaPago = TipoFormaPago.Tarjeta,
                            ComprobanteId = _comprobante.Id,
                            Monto = _pago2,
                            NumeroTarjeta = ((TextBox)pnlPago2.Controls["txtNumeroTarjeta"]).Text,
                            PlanTarjetaId = ((PlanTarjetaDto)((ComboBox)pnlPago2.Controls["cmbPlanDeTarjeta"]).SelectedItem).Id,
                            Numero = ((TextBox)pnlPago2.Controls["txtCodigo"]).Text,
                            Cupon = ""
                        });
                        _comprobante.MontoTarjeta += _pago2;
                        break;
                    case "cuenta corriente":
                        _formaPagoServicio.Agregar(new FormaPagoCtaCteDto
                        {
                            TipoFormaPago = TipoFormaPago.CuentaCorriente,
                            Monto = _pago2,
                            ComprobanteId = _comprobante.Id,
                            ClienteId = _clienteId
                        });
                        _comprobante.MontoCtaCte += _pago2;
                        break;
                }
            }
            Realizo = true;
            _comprobante.TipoComprobante = _tipoComprobante;
            _deliveryServicio.Entregar(_comprobante);
            if (MessageBox.Show("¿Desea imprimir el comprobante?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var fComprobante = new Core.Delivery.ComprobanteEnvio(_comprobante.Id);
                fComprobante.ShowDialog();
            }
            Notificacion.NotificacionCorrecta.MensajeSatisfactorio("Compra satisfactoria");
            this.Close();
        }
    }
}
