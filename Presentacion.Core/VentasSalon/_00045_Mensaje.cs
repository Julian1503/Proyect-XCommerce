namespace Presentacion.Core.Ventas
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Cliente;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.Cliente;
    using XCommerce.Servicio.Core.CompranteMesa;
    using XCommerce.Servicio.Core.CuentaCorriente;
    using XCommerce.Servicio.Core.Movimiento;
    public partial class _00045_Mensaje : FormularioBase.FormularioBase
    {
        private readonly IMovimientoServicio _movimientoServicio;
        private readonly IComprobanteMesaServicio _comprobanteMesaServicio;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private readonly IClienteServicio _clienteServicio;
        public bool Efectivo { get; private set; }
        private decimal _total { get; set; }
        private TipoComprobante _tipoComprobante { get; set; }
        public bool CtaCte { get; private set; }
        private long _mesaId;
        public bool Realizo;
        private long _clienteId;

        public _00045_Mensaje()
        {
            InitializeComponent();
        }

        public _00045_Mensaje(long mesaId) : this( new CuentaCorrienteServicio(),new ComprobanteMesaServicio(), new ClienteServicio())
        {
            Realizo = false;
            _mesaId = mesaId;
            _total = _comprobanteMesaServicio.ObtenerComprobanteMesa(_mesaId).Total;
            Efectivo = false;
            CtaCte = false;
            _tipoComprobante = TipoComprobante.X;
        }
        public _00045_Mensaje(ICuentaCorrienteServicio cuentaCorrienteServicio,IComprobanteMesaServicio comprobanteMesaServicio,IClienteServicio clienteServicio) :this()
        {
            _comprobanteMesaServicio = comprobanteMesaServicio;
            _clienteServicio = clienteServicio;
            _cuentaCorrienteServicio = cuentaCorrienteServicio;
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            InicializarPantalla();
            var lblComprobante = new Label
            {
                AutoSize = true,
                Location = new Point(12, 146),
                Name = "lblComprobante",
                Size = new Size(109, 13),
                TabIndex = 4,
                Text = "Tipo de Comprobante",
            };
            var cmbComprobante = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(127, 143),
                Name = "cmbComprobante",
                Size = new Size(197, 21),
                TabIndex = 3,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbComprobante.Items.AddRange(new object[]
            {
                "Factura-A",
                "Factura-B",
                "Factura-C",
                "Factura-X"
            });
            cmbComprobante.SelectionChangeCommitted += cmbComprobante_SelectionChangeCommitted;
            cmbComprobante.SelectedIndex = 0;
          
            var lblTotal = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(12, 236),
                Name = "lblTotal",
                Size = new Size(85, 25),
                TabIndex = 6,
                Text = "TOTAL",
            };

            var txtTotal = new TextBox
            {
                Enabled = false,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold,
                    GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(101, 230),
                Name = "txtTotal",
                Size = new Size(191, 31),
                TabIndex = 5,
            };
            txtTotal.Text = _total.ToString("C");
            this.Controls.Add(txtTotal);
            this.Controls.Add(lblComprobante);
            this.Controls.Add(cmbComprobante);
            this.Controls.Add(lblTotal);
            Efectivo = true;
            CtaCte = false;
        }

        private void cmbComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (((ComboBox) sender).SelectedIndex)
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
                default:
                    _tipoComprobante = TipoComprobante.X;
                    break;
            }
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            if (Efectivo)
            {
                //_comprobanteMesaServicio.CerrarMesa(_tipoComprobante,
                //    _comprobanteMesaServicio.ObtenerComprobanteMesa(_mesaId),
                //    TipoPago.Efectivo);
                MessageBox.Show(@"Su Comprobante se esta imprimiendo"
                    ,@"Venta Realizada",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                Realizo = true;
                this.Close();
            }
            else if(CtaCte)
            {
                var cliente = _clienteServicio.ObtenerPorId(_clienteId);
                var saldo = _cuentaCorrienteServicio.ObtenerCorrientePorClienteId(_clienteId).Saldo;
                if ((saldo+_total)<=cliente.Sobregiro)
                {
                    //_comprobanteMesaServicio.CerrarMesa(TipoComprobante.X,
                    //    _comprobanteMesaServicio.ObtenerComprobanteMesa(_mesaId),
                    //    TipoPago.CtaCte,cliente.Id);
                    MessageBox.Show(@"Su Comprobante se esta imprimiendo"
                        , @"Venta Realizada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Realizo = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El cliente no tiene Saldo para hacer esta compra con Cuenta Corriente",
                        "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void InicializarPantalla()
        {
            foreach (var i in this.Controls.OfType<Label>())
            {
                this.Controls.Remove(i);
            }
            foreach (var i in this.Controls.OfType<Button>())
            {
                this.Controls.Remove(i);
            }
            foreach (var i in this.Controls.OfType<ComboBox>())
            {
                this.Controls.Remove(i);
            }
            foreach (var i in this.Controls.OfType<TextBox>())
            {
                this.Controls.Remove(i);
            }
            var lblPregunta = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(-1, 30),
                Name = "lblPregunta",
                Size = new Size(384, 20),
                TabIndex = 2,
                Text = "¿Desea pagar en Efectivo o Cuenta Corriente?",
            };
            var btnCuentaCorriente = new Button
            {
                Location = new Point(53, 75),
                Name = "btnCtaCte",
                Size = new Size(114, 36),
                TabIndex = 0,
                Text = "Cuenta Corriente",
                UseVisualStyleBackColor = true
            };
            btnCuentaCorriente.Click += btnCtaCte_Click;
            var btnEfect = new Button
            {
                Location = new Point(210, 75),
                Name = "btnEfectivo",
                Size = new Size(114, 36),
                TabIndex = 1,
                Text = "Efectivo",
                UseVisualStyleBackColor = true,
            };

            var btnPagar = new Button
            {
                Font = new Font("Microsoft Sans Serif", 11.25F,
                    FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(137, 279),
                Name = "btnPagar",
                Size = new Size(98, 28),
                TabIndex = 5,
                Text = "PAGAR",
                UseVisualStyleBackColor = true
            };

            btnEfect.Click += btnEfectivo_Click;
            this.Controls.Add(lblPregunta);
            this.Controls.Add(btnEfect);
            this.Controls.Add(btnCuentaCorriente);
            this.Controls.Add(btnPagar);
            btnPagar.Click += BtnPagar_Click;
            //if (texto.Equals("Cuenta Corriente"))
            //{
            //    btnCtaCte.Enabled = false;
            //    btnEfect.Enabled = true;
            //}
            //if(texto.Equals("Efectivo"))
            //{
            //    btnCtaCte.Enabled = true;
            //    btnEfect.Enabled = false;
            //}
        }

        private void btnCtaCte_Click(object sender, EventArgs e)
        {
            InicializarPantalla();
            var txtCliente = new TextBox
            {
                ReadOnly=true,
                Location = new Point(101, 171),
                Name = "txtCliente",
                Size = new Size(191, 20),
                TabIndex = 3
            };
            var lblCliente = new Label
            {
                AutoSize = true,
                Location = new Point(58, 174),
                Name = "lblCliente",
                Size = new Size(39, 13),
                TabIndex = 4,
                Text = "Cliente"
            };
            var txtTotal = new TextBox
            {
                Enabled = false,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold,
                    GraphicsUnit.Point, ((byte) (0))),
                Location = new Point(101, 230),
                Name = "txtTotal",
                Size = new Size(191, 31),
                TabIndex = 5,
            };
            var lblTotal = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0))),
                Location = new Point(12, 236),
                Name = "lblTotal",
                Size = new Size(85, 25),
                TabIndex = 6,
                Text = "TOTAL",
            };
            txtTotal.Text = _total.ToString("C");
            txtCliente.KeyPress += txtCliente_KeyPress;
            this.Controls.Add(txtCliente);
            this.Controls.Add(lblCliente);
            this.Controls.Add(txtTotal);
            this.Controls.Add(lblTotal);
            CtaCte = true;
            Efectivo = false;
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
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
    }


}

