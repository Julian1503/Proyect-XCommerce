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
using XCommerce.Servicio.Core.Banco.DTOs;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.CompranteMesa;
using XCommerce.Servicio.Core.CompranteMesa.DTOs;
using XCommerce.Servicio.Core.CuentaCorriente;
using XCommerce.Servicio.Core.DetalleCaja;
using XCommerce.Servicio.Core.Entidad;
using XCommerce.Servicio.Core.FormaPago;
using XCommerce.Servicio.Core.FormaPago.DTOs;
using XCommerce.Servicio.Core.Movimiento;
using XCommerce.Servicio.Core.Operacion;
using XCommerce.Servicio.Core.PlanTarjeta;
using XCommerce.Servicio.Core.PlanTarjeta.DTOs;

namespace Presentacion.Core.FormaPago
{
    public partial class FormaPagoMesa : FormularioPagoBase
    {
        private readonly IComprobanteMesaServicio _comprobanteMesaServicio;
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private readonly IOperacionServicio _operacionServicio;
        private readonly IFormaPago _formaPagoServicio;
        public bool Realizo;
        private ComprobanteMesaDto _comprobante;
        private decimal _pago1;
        private decimal _pago2;
        public FormaPagoMesa() : base()
        {
            InitializeComponent();
        }
        public FormaPagoMesa(ICuentaCorrienteServicio cuentaCorrienteServicio,
            IFormaPago formaPagoServicio, IDetalleCajaServicio detalleCajaServicio, IComprobanteMesaServicio comprobanteMesaServicio, IOperacionServicio operacionServicio) : this()
        {
            _formaPagoServicio = formaPagoServicio;
            _operacionServicio = operacionServicio;
            _detalleCajaServicio = detalleCajaServicio;
            _comprobanteMesaServicio = comprobanteMesaServicio;
            _cuentaCorrienteServicio = cuentaCorrienteServicio;
            _pago1 = 0;
            _pago2 = 0;
        }
        public FormaPagoMesa(long mesaId) : this(new CuentaCorrienteServicio(), new FormaPagoServicio(), new DetalleCajaServicio(), new ComprobanteMesaServicio(), new OperacionServicio())
        {
            _comprobante = _comprobanteMesaServicio.ObtenerComprobanteMesa(mesaId);
            SetTotal(_comprobante.Total);
        }

        protected override void FinalizacionDelPago(string primerPago, string segundoPago, Panel pnlPago1, Panel pnlPago2)
        {
            base.FinalizacionDelPago(primerPago, segundoPago,pnlPago1,pnlPago2);
            if (!primerPago.Equals(""))
            {
            _pago1 = ((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value;
                switch (primerPago)
                {
                    case "efectivo":
                        _pago1 = ((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value - _vuelto ;
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
                    case "cheque":
                        _detalleCajaServicio.Generar(_pago1, TipoPago.Cheque);
                        _formaPagoServicio.Agregar(new FormaPagoChequeDto
                        {
                            TipoFormaPago = TipoFormaPago.Cheque,
                            ComprobanteId = _comprobante.Id,
                            Monto = _pago1,
                            BancoId = _bancoId,
                            Dias = (int)((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value,
                            EnteEmisor = ((TextBox)pnlPago1.Controls["txtEnteEmisorCheque"]).Text,
                            FechaEmision = ((DateTimePicker)pnlPago1.Controls["dtpFechaCheque"]).Value,
                            Numero = ((TextBox)pnlPago1.Controls["txtNumeroCheque"]).Text,
                            EstadoCheque = EstadoCheque.SinCobrar
                        });
                        _comprobante.MontoCheque += _pago1;
                        break;
                    case "cuenta corriente":
                        _detalleCajaServicio.Generar(_pago1, TipoPago.CtaCte);
                        _cuentaCorrienteServicio.Vender(_clienteId, _comprobante.Total);
                        _operacionServicio.Agregar(new OperacionDto
                        {
                            TipoOperacion = TipoOperacion.Venta,
                            ComprobanteId = _comprobante.Id,
                            Fecha = DateTime.Now,
                            Monto = _pago1,
                            CuentaCorrienteId = _cuentaCorrienteServicio.ObtenerCorrientePorClienteId(_clienteId).Id
                        });
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
                    case "cheque":
                        _formaPagoServicio.Agregar(new FormaPagoChequeDto
                        {
                            TipoFormaPago = TipoFormaPago.Cheque,
                            ComprobanteId = _comprobante.Id,
                            Monto = _pago2,
                            BancoId = _bancoId,
                            Dias = (int)((NumericUpDown)pnlPago2.Controls["nudMonto"]).Value,
                            EnteEmisor = ((TextBox)pnlPago2.Controls["txtEnteEmisorCheque"]).Text,
                            FechaEmision = ((DateTimePicker)pnlPago2.Controls["dtpFechaCheque"]).Value,
                            Numero = ((TextBox)pnlPago2.Controls["txtNumeroCheque"]).Text,
                            EstadoCheque = EstadoCheque.SinCobrar

                        });
                        _comprobante.MontoCheque += _pago2;
                        break;
                    case "cuenta corriente":
                        _detalleCajaServicio.Generar(_pago2, TipoPago.CtaCte);
                        _cuentaCorrienteServicio.Vender(_clienteId, _comprobante.Total);
                        _operacionServicio.Agregar(new OperacionDto
                        {
                            TipoOperacion = TipoOperacion.Venta,
                            ComprobanteId = _comprobante.Id,
                            Fecha = DateTime.Now,
                            Monto = _pago2,
                            CuentaCorrienteId = _cuentaCorrienteServicio.ObtenerCorrientePorClienteId(_clienteId).Id
                        });
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
            _comprobanteMesaServicio.CerrarMesa(_comprobante, _tipoComprobante);
            if (MessageBox.Show("¿Desea imprimir el comprobante?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var comprobanteSalon = new VentasSalon.ComprobanteSalon(_comprobante.Id);
                comprobanteSalon.ShowDialog();
            }
            Entidad.VentasHoy = _movimientoServicio.ObtenerVentasHoy();
            Notificacion.NotificacionCorrecta.MensajeSatisfactorio("Compra satisfactoria");
            this.Close();
        }
    }
}
