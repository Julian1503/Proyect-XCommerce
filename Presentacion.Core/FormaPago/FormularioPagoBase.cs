using Bunifu.Framework.UI;
using Presentacion.Core.Banco;
using Presentacion.Core.Cliente;
using Presentacion.Core.PlanTarjeta;
using Presentacion.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.PlanTarjeta;

namespace Presentacion.Core.FormaPago
{
    public partial class FormularioPagoBase : FormularioBase.FormularioBase
    {
        private bool _cambio;
        private string _primerPago;
        private string _segundoPago;
        private decimal _valor1;
        private decimal _valor2;
        private decimal _pago1;
        private decimal _pago2;
        protected decimal _vuelto;
        protected long _bancoId;
        protected long _clienteId;
        protected TipoComprobante _tipoComprobante;
        private readonly IPlanTarjetaServicio _planTarjetaServicio;

        public FormularioPagoBase() :this(new PlanTarjetaServicio())
        {
            InitializeComponent();
            _primerPago = "";
            _segundoPago = "";
            _valor1 = 0;
            _valor2 = 0;
            cmbTipoFactura.SelectedIndex = 0;
            _tipoComprobante = TipoComprobante.A;
            btnCuentaCorriente.LabelText = @"Cuenta 
Corriente";
        }
        public FormularioPagoBase(IPlanTarjetaServicio planTarjetaServicio)
        {
            _planTarjetaServicio = planTarjetaServicio;
        }

        protected void SetTotal(decimal valor)
        {
            nudTotal.Value = valor;
        }

        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            if (!_cambio)
            {
                btnAtras1.Visible = true;
                lblPago1.Visible = true;
               _primerPago = ((BunifuTileButton)sender).Tag.ToString();
                lblPago1.Text = $"Pago con {((BunifuTileButton)sender).Tag}";
                _cambio = true;
                QuitarControladores(pnlPago1);
                GenerarControles(((BunifuTileButton)sender).Tag.ToString(), pnlPago1);
            }
            else
            {
               
                btnAtras2.Visible = true;
                lblPago2.Visible = true;
                lblPago2.Text = $"Pago con {((BunifuTileButton)sender).Tag}";
                _segundoPago = ((BunifuTileButton)sender).Tag.ToString();
                QuitarControladores(pnlPago2);
                GenerarControles(((BunifuTileButton)sender).Tag.ToString(), pnlPago2);
                _cambio = false;
            }
        }

        private void QuitarControladores(Control parent)
        {
            parent.Controls.Clear();
        }

        private void GenerarControles(string formaPago,Control control)
        {
            var lblMonto = new Label();
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(32, 19);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(76, 13);
            lblMonto.TabIndex = 15;
            lblMonto.Text = "Monto a pagar";
            control.Controls.Add(lblMonto);

            //Numeric Up Down de Monto Efectivo
            var nudMonto = new NumericUpDown();
            nudMonto.Location = new Point(114, 17);
            nudMonto.Maximum = 9999999999;
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(124, 20);
            nudMonto.TabIndex = 16;
            nudMonto.ValueChanged += nudMonto_ValueChanged;
            control.Controls.Add(nudMonto);
            switch (formaPago.ToLower())
            {
                case "cuenta corriente":
                    { 
                        //TextBox de cliente
                        var txtCliente = new TextBox();
                        txtCliente.Location = new Point(114, 44);
                        txtCliente.Name = "txtCliente";
                        txtCliente.ReadOnly = true;
                        txtCliente.Size = new Size(120, 20);
                        txtCliente.TabIndex = 25;
                        txtCliente.KeyPress += txtCliente_KeyPress;
                        control.Controls.Add(txtCliente);
                        //Label de cliente
                        var lblCliente = new Label();
                        lblCliente.AutoSize = true;
                        lblCliente.Location = new Point(69, 47);
                        lblCliente.Name = "label7";
                        lblCliente.Size = new Size(39, 13);
                        lblCliente.TabIndex = 26;
                        lblCliente.Text = "Cliente";
                        control.Controls.Add(lblCliente);
                        //Button de cliente
                        var btnNuevoCliente = new Button();
                        btnNuevoCliente.Location = new Point(240, 43);
                        btnNuevoCliente.Name = "btnNuevoCliente";
                        btnNuevoCliente.Size = new Size(25, 21);
                        btnNuevoCliente.TabIndex = 27;
                        btnNuevoCliente.Text = "+";
                        btnNuevoCliente.UseVisualStyleBackColor = true;
                        btnNuevoCliente.Click += btnNuevoCliente_Click;
                        control.Controls.Add(btnNuevoCliente);
                    }
                    break;
                case "tarjeta":
                    { 
                        //Label Numero tarjeta
                        var lblNumeroTarjeta = new Label();
                        lblNumeroTarjeta.AutoSize = true;
                        lblNumeroTarjeta.Location = new Point(17, 47);
                        lblNumeroTarjeta.Name = "label1";
                        lblNumeroTarjeta.Size = new Size(91, 13);
                        lblNumeroTarjeta.TabIndex = 23;
                        lblNumeroTarjeta.Text = "Numero de tarjeta";
                        control.Controls.Add(lblNumeroTarjeta);
                        //TextBox Numero Tarjeta
                        var txtNumeroTarjeta = new TextBox();
                        txtNumeroTarjeta.Location = new Point(114, 44);
                        txtNumeroTarjeta.Name = "txtNumeroTarjeta";
                        txtNumeroTarjeta.Size = new Size(124, 20);
                        txtNumeroTarjeta.TabIndex = 22;
                        control.Controls.Add(txtNumeroTarjeta);
                        //Label plan
                        var lblPlan = new Label();
                        lblPlan.AutoSize = true;
                        lblPlan.Location = new Point(80, 73);
                        lblPlan.Name = "label4";
                        lblPlan.Size = new Size(28, 13);
                        lblPlan.TabIndex = 25;
                        lblPlan.Text = "Plan";
                        control.Controls.Add(lblPlan);
                        //Button agregar plan
                        var btnNuevoPlan = new Button();
                        btnNuevoPlan.Location = new Point(242, 69);
                        btnNuevoPlan.Name = "cmbNuevoPlan";
                        btnNuevoPlan.Size = new Size(25, 21);
                        btnNuevoPlan.TabIndex = 28;
                        btnNuevoPlan.Text = "+";
                        btnNuevoPlan.UseVisualStyleBackColor = true;
                        btnNuevoPlan.Click += cmbNuevoPlan_Click;
                        control.Controls.Add(btnNuevoPlan);
                        //ComboBox plan
                        var cmbPlanDeTarjeta = new ComboBox();
                        cmbPlanDeTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbPlanDeTarjeta.FormattingEnabled = true;
                        cmbPlanDeTarjeta.Location = new Point(114, 70);
                        cmbPlanDeTarjeta.Name = "cmbPlanDeTarjeta";
                        cmbPlanDeTarjeta.Size = new Size(124, 21);
                        cmbPlanDeTarjeta.TabIndex = 24;
                        control.Controls.Add(cmbPlanDeTarjeta);
                        CargarComboBox(cmbPlanDeTarjeta, _planTarjetaServicio.Obtener(string.Empty), "Descripcion", "Id");
                        // txtCodigo
                        var txtCodigo = new TextBox();
                        txtCodigo.Location = new Point(114, 97);
                        txtCodigo.Name = "txtCodigo";
                        txtCodigo.Size = new Size(58, 20);
                        txtCodigo.TabIndex = 26;
                        control.Controls.Add(txtCodigo);
                        // lblCodigo
                        var lblCodigo = new Label();
                        lblCodigo.AutoSize = true;
                        lblCodigo.Location = new Point(68, 100);
                        lblCodigo.Name = "lblCodigo";
                        lblCodigo.Size = new Size(40, 13);
                        lblCodigo.TabIndex = 27;
                        lblCodigo.Text = "Codigo";
                        control.Controls.Add(lblCodigo);
                    }
                    break;
                case "cheque":
                    {
                        
                        // lblDias
                        var lblDias = new Label();
                        lblDias.AutoSize = true;
                        lblDias.Location = new Point(80, 150);
                        lblDias.Name = "label18";
                        lblDias.Size = new Size(28, 13);
                        lblDias.TabIndex = 39;
                        lblDias.Text = "Dias";
                        control.Controls.Add(lblDias);
                        // lblFecha
                        var lblFecha = new Label();
                        lblFecha.AutoSize = true;
                        lblFecha.Location = new Point(18, 128);
                        lblFecha.Name = "label17";
                        lblFecha.Size = new Size(90, 13);
                        lblFecha.TabIndex = 38;
                        lblFecha.Text = "Fecha de emision";
                        control.Controls.Add(lblFecha);
                        // lblNumeroCheque
                        var lblNumeroCheque = new Label();
                        lblNumeroCheque.AutoSize = true;
                        lblNumeroCheque.Location = new Point(50, 47);
                        lblNumeroCheque.Name = "label10";
                        lblNumeroCheque.Size = new Size(58, 13);
                        lblNumeroCheque.TabIndex = 33;
                        lblNumeroCheque.Text = "N° cheque";
                        control.Controls.Add(lblNumeroCheque);
                        // lblEntidad
                        var lblEntidad = new Label();
                        lblEntidad.AutoSize = true;
                        lblEntidad.Location = new Point(21, 99);
                        lblEntidad.Name = "label11";
                        lblEntidad.Size = new Size(87, 13);
                        lblEntidad.TabIndex = 31;
                        lblEntidad.Text = "Entidad bancaria";
                        control.Controls.Add(lblEntidad);
                        // lblEnteEmisor
                        var lblEnteEmisor = new Label();
                        lblEnteEmisor.AutoSize = true;
                        lblEnteEmisor.Location = new Point(46, 73);
                        lblEnteEmisor.Name = "label5";
                        lblEnteEmisor.Size = new Size(62, 13);
                        lblEnteEmisor.TabIndex = 36;
                        lblEnteEmisor.Text = "Ente emisor";
                        control.Controls.Add(lblEnteEmisor);
                        // nudDias
                        var nudDias = new NumericUpDown();
                        nudDias.Location = new Point(114, 148);
                        nudDias.Maximum = 9999;
                        nudDias.Name = "nudDias";
                        nudDias.Size = new Size(124, 20);
                        nudDias.TabIndex = 40;
                        control.Controls.Add(nudDias);
                        // txtBancos
                        var txtBancos = new TextBox();
                        txtBancos.Location = new Point(114, 96);
                        txtBancos.Name = "txtBancos";
                        txtBancos.ReadOnly = true;
                        txtBancos.Size = new Size(124, 20);
                        txtBancos.TabIndex = 30;
                        txtBancos.KeyPress += txtBancos_KeyPress;
                        control.Controls.Add(txtBancos);
                        // txtNumeroCheque
                        var txtNumeroCheque = new TextBox();
                        txtNumeroCheque.Location = new Point(114, 44);
                        txtNumeroCheque.Name = "txtNumeroCheque";
                        txtNumeroCheque.Size = new Size(124, 20);
                        txtNumeroCheque.TabIndex = 32;
                        control.Controls.Add(txtNumeroCheque);
                        // btnNuevoBanco
                        var btnNuevoBanco = new Button();
                        btnNuevoBanco.Location = new Point(242, 95);
                        btnNuevoBanco.Name = "btnNuevoBanco";
                        btnNuevoBanco.Size = new Size(25, 21);
                        btnNuevoBanco.TabIndex = 34;
                        btnNuevoBanco.Text = "+";
                        btnNuevoBanco.UseVisualStyleBackColor = true;
                        btnNuevoBanco.Click += btnNuevoBanco_Click;
                        control.Controls.Add(btnNuevoBanco);
                        // txtEnteEmisorCheque
                        var txtEnteEmisorCheque = new TextBox();
                        txtEnteEmisorCheque.Location = new Point(114, 70);
                        txtEnteEmisorCheque.Name = "txtEnteEmisorCheque";
                        txtEnteEmisorCheque.Size = new Size(124, 20);
                        txtEnteEmisorCheque.TabIndex = 35;
                        control.Controls.Add(txtEnteEmisorCheque);
                        // dtpFechaCheque
                        var dtpFechaCheque = new DateTimePicker();
                        dtpFechaCheque.Format = DateTimePickerFormat.Short;
                        dtpFechaCheque.Location = new Point(114, 122);
                        dtpFechaCheque.Name = "dtpFechaCheque";
                        dtpFechaCheque.Size = new Size(124, 20);
                        dtpFechaCheque.TabIndex = 37;
                        control.Controls.Add(dtpFechaCheque);
                    }
                    break;
            }
        }

        

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var fC = new _10007_BuscarPorCtaCte();
                fC.ShowDialog();
                if (fC.RealizoOperacion)
                {
                    ((TextBox)sender).Text = fC.Cliente.ApyNom + $" DNI:{fC.Cliente.Dni}";
                    _clienteId = fC.Cliente.Id;
                }
            }
        }

        private void txtBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var banco = new _00001_BuscarBancos();
                banco.ShowDialog();
                if (banco.RealizoOperacion)
                {
                    ((TextBox)sender).Text = banco.NombreBanco;
                    _bancoId = banco.BancoId;
                }
            }
        }


        private void btnNuevoBanco_Click(object sender, EventArgs e)
        {
            var fbanco = new _00022_ABM_Banco(TipoOp.Nuevo);
            fbanco.ShowDialog();
        }
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            var fClienteAbm = new _00004_ABM_Cliente(TipoOp.Nuevo);
            fClienteAbm.ShowDialog();
        }

        private void cmbNuevoPlan_Click(object sender, EventArgs e)
        {
            var cmbPlan = ((ComboBox)((Panel)((Button)sender).Parent).Controls["cmbPlanDeTarjeta"]);
            var fPlanTarjeta = new _00039_ABM_PlanTarjeta(TipoOp.Nuevo);
            fPlanTarjeta.ShowDialog();
            if (fPlanTarjeta.RealizoAlgunaOperacion)
            {
                CargarComboBox(cmbPlan, _planTarjetaServicio.Obtener(string.Empty), "Descripcion", "Id");
            }
        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {
            if (nudPago.Value + ((NumericUpDown)sender).Value < nudPago.Maximum)
            {
                if (((NumericUpDown)sender).Parent == pnlPago1)
                {
                    nudPago.Value -= _valor1;
                    _valor1 = ((NumericUpDown)sender).Value;
                }
                else
                {
                    nudPago.Value -= _valor2;
                    _valor2 = ((NumericUpDown)sender).Value;
                }
                nudPago.Value += ((NumericUpDown)sender).Value;
                _vuelto = nudVuelto.Value;
            }
            else
            {
                Notificacion.NotificacionIncorrecta.MensajeCuidado("Numero muy grande", "Por favor ingrese un valor acorde a su pago");
            }
        }

        private void btnAtras1_Click(object sender, EventArgs e)
        {
            btnAtras1.Visible = false;
            if (!btnEfectivo.Enabled)
            {
                btnEfectivo.Enabled = true;
            }
            if (nudPago.Value>=((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value)
           {
                nudPago.Value -= ((NumericUpDown)pnlPago1.Controls["nudMonto"]).Value;
            }
            lblPago1.Visible = false;
            _cambio = false;
            _primerPago = "";
            QuitarControladores(pnlPago1);
            var lblPresentacionPago1 = new Label();
            lblPresentacionPago1.AutoSize = true;
            lblPresentacionPago1.Location = new Point(59, 90);
            lblPresentacionPago1.Name = "lblPresentacionPago1";
            lblPresentacionPago1.Size = new Size(152, 13);
            lblPresentacionPago1.TabIndex = 14;
            lblPresentacionPago1.Text = "Seleccione una forma de pago";
            pnlPago1.Controls.Add(lblPresentacionPago1);
        }

        private void btnAtras2_Click(object sender, EventArgs e)
        {
            btnAtras2.Visible = false;
            lblPago2.Visible = false;
            if(nudPago.Value >= ((NumericUpDown)pnlPago2.Controls["nudMonto"]).Value)
            {
                nudPago.Value -= ((NumericUpDown)pnlPago2.Controls["nudMonto"]).Value;
            }
            _segundoPago = "";
            _cambio = true;
            if (!btnAtras1.Visible)
            {
                _cambio =false;
            }

            QuitarControladores(pnlPago2);
            var lblPresentacionPago2 = new Label();
            lblPresentacionPago2.AutoSize = true;
            lblPresentacionPago2.Location = new Point(59, 90);
            lblPresentacionPago2.Name = "lblPresentacionPago2";
            lblPresentacionPago2.Size = new Size(152, 13);
            lblPresentacionPago2.TabIndex = 14;
            lblPresentacionPago2.Text = "Seleccione una forma de pago";
            pnlPago2.Controls.Add(lblPresentacionPago2);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
           if(_primerPago.Equals("") && _segundoPago.Equals(""))
            {
                Notificacion.NotificacionIncorrecta.MensajeCuidado("Ninguna forma de pago", "No se selecciono ninguna forma de pago, por favor seleccione alguna");
                return;
            }
            if (_valor1 + _valor2 == nudTotal.Value)
            {
                FinalizacionDelPago(_primerPago.ToLower(), _segundoPago.ToLower(), pnlPago1, pnlPago2);
            }
        }

        protected virtual void FinalizacionDelPago(string primerPago, string segundoPago, Panel pnlPago1, Panel pnlPago2)
        {

        }

        private void nudPago_ValueChanged(object sender, EventArgs e)
        {
            nudVuelto.Value = Vuelto.CambiarVuelto(nudTotal.Value, nudPago.Value);
        }

        private void cmbTipoFactura_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cmbTipoFactura.SelectedIndex)
            {
                case 0:
                    _tipoComprobante = TipoComprobante.A;
                    break;

                case 1:
                    _tipoComprobante = TipoComprobante.B;

                    break;
                case 2:
                    _tipoComprobante = TipoComprobante.C;

                    break;
                case 3:
                    _tipoComprobante = TipoComprobante.X;

                    break;

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
