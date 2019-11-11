namespace Presentacion.Core.Delivery
{
    partial class Comprobante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comprobante));
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterRight = new System.Windows.Forms.Panel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalComprobante = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlDescuento = new System.Windows.Forms.Panel();
            this.lblDescuentoComprobante = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.pnlSubtotal = new System.Windows.Forms.Panel();
            this.lblSubtotalComprobante = new System.Windows.Forms.Label();
            this.lblSubtotalFooter = new System.Windows.Forms.Label();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblCuitCliente = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblCondicionIv = new System.Windows.Forms.Label();
            this.lblDomicilioEmpresa = new System.Windows.Forms.Label();
            this.lblRazonSocialEmpresa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumeroComprobante = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.pnlTipoComprobante = new System.Windows.Forms.Panel();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlBtnImprimir = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pnlCerrar = new System.Windows.Forms.Panel();
            this.btnCerrar = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlContenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFooterRight.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlDescuento.SuspendLayout();
            this.pnlSubtotal.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTipoComprobante.SuspendLayout();
            this.pnlBtnImprimir.SuspendLayout();
            this.pnlCerrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Controls.Add(this.panel1);
            this.pnlContenedor.Controls.Add(this.pnlCabecera);
            this.pnlContenedor.Location = new System.Drawing.Point(9, 281);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(667, 205);
            this.pnlContenedor.TabIndex = 0;
            this.pnlContenedor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlFooter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 139);
            this.panel1.TabIndex = 1;
            this.panel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlAdded);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.pnlFooterRight);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(665, 139);
            this.pnlFooter.TabIndex = 0;
            // 
            // pnlFooterRight
            // 
            this.pnlFooterRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFooterRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooterRight.Controls.Add(this.pnlTotal);
            this.pnlFooterRight.Controls.Add(this.pnlDescuento);
            this.pnlFooterRight.Controls.Add(this.pnlSubtotal);
            this.pnlFooterRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFooterRight.Location = new System.Drawing.Point(407, 0);
            this.pnlFooterRight.Name = "pnlFooterRight";
            this.pnlFooterRight.Size = new System.Drawing.Size(258, 139);
            this.pnlFooterRight.TabIndex = 0;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotal.Controls.Add(this.lblTotalComprobante);
            this.pnlTotal.Controls.Add(this.lblTotal);
            this.pnlTotal.Location = new System.Drawing.Point(0, 82);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(258, 59);
            this.pnlTotal.TabIndex = 0;
            // 
            // lblTotalComprobante
            // 
            this.lblTotalComprobante.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalComprobante.Location = new System.Drawing.Point(118, 0);
            this.lblTotalComprobante.Name = "lblTotalComprobante";
            this.lblTotalComprobante.Size = new System.Drawing.Size(140, 58);
            this.lblTotalComprobante.TabIndex = 8;
            this.lblTotalComprobante.Text = "$0";
            this.lblTotalComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Poppins Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(17, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 42);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total";
            // 
            // pnlDescuento
            // 
            this.pnlDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDescuento.Controls.Add(this.lblDescuentoComprobante);
            this.pnlDescuento.Controls.Add(this.lblDescuento);
            this.pnlDescuento.Location = new System.Drawing.Point(0, 41);
            this.pnlDescuento.Name = "pnlDescuento";
            this.pnlDescuento.Size = new System.Drawing.Size(258, 41);
            this.pnlDescuento.TabIndex = 9;
            // 
            // lblDescuentoComprobante
            // 
            this.lblDescuentoComprobante.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoComprobante.Location = new System.Drawing.Point(118, 3);
            this.lblDescuentoComprobante.Name = "lblDescuentoComprobante";
            this.lblDescuentoComprobante.Size = new System.Drawing.Size(140, 35);
            this.lblDescuentoComprobante.TabIndex = 7;
            this.lblDescuentoComprobante.Text = "$0";
            this.lblDescuentoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(2, 6);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(97, 28);
            this.lblDescuento.TabIndex = 7;
            this.lblDescuento.Text = "Descuento";
            // 
            // pnlSubtotal
            // 
            this.pnlSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubtotal.Controls.Add(this.lblSubtotalComprobante);
            this.pnlSubtotal.Controls.Add(this.lblSubtotalFooter);
            this.pnlSubtotal.Location = new System.Drawing.Point(0, 0);
            this.pnlSubtotal.Name = "pnlSubtotal";
            this.pnlSubtotal.Size = new System.Drawing.Size(258, 41);
            this.pnlSubtotal.TabIndex = 8;
            // 
            // lblSubtotalComprobante
            // 
            this.lblSubtotalComprobante.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalComprobante.Location = new System.Drawing.Point(118, 0);
            this.lblSubtotalComprobante.Name = "lblSubtotalComprobante";
            this.lblSubtotalComprobante.Size = new System.Drawing.Size(140, 41);
            this.lblSubtotalComprobante.TabIndex = 7;
            this.lblSubtotalComprobante.Text = "$0";
            this.lblSubtotalComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtotalFooter
            // 
            this.lblSubtotalFooter.AutoSize = true;
            this.lblSubtotalFooter.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalFooter.Location = new System.Drawing.Point(20, 6);
            this.lblSubtotalFooter.Name = "lblSubtotalFooter";
            this.lblSubtotalFooter.Size = new System.Drawing.Size(79, 28);
            this.lblSubtotalFooter.TabIndex = 7;
            this.lblSubtotalFooter.Text = "Subtotal";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.lblSubtotal);
            this.pnlCabecera.Controls.Add(this.lblPrecio);
            this.pnlCabecera.Controls.Add(this.lblCantidad);
            this.pnlCabecera.Controls.Add(this.lblDescripcion);
            this.pnlCabecera.Controls.Add(this.lblCod);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(665, 64);
            this.pnlCabecera.TabIndex = 0;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(544, 19);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(81, 28);
            this.lblSubtotal.TabIndex = 10;
            this.lblSubtotal.Text = "SubTotal";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(428, 19);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(61, 28);
            this.lblPrecio.TabIndex = 9;
            this.lblPrecio.Text = "Precio";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(303, 19);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(88, 28);
            this.lblCantidad.TabIndex = 8;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(139, 19);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(106, 28);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCod.Location = new System.Drawing.Point(12, 19);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(48, 28);
            this.lblCod.TabIndex = 6;
            this.lblCod.Text = "Cod.";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.panel2);
            this.pnlHeader.Controls.Add(this.bunifuSeparator1);
            this.pnlHeader.Controls.Add(this.lblCondicionIv);
            this.pnlHeader.Controls.Add(this.lblDomicilioEmpresa);
            this.pnlHeader.Controls.Add(this.lblRazonSocialEmpresa);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.lblNumeroComprobante);
            this.pnlHeader.Controls.Add(this.lblFecha);
            this.pnlHeader.Controls.Add(this.lblCuit);
            this.pnlHeader.Location = new System.Drawing.Point(9, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(667, 270);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDomicilio);
            this.panel2.Controls.Add(this.lblNombreCliente);
            this.panel2.Controls.Add(this.lblCuitCliente);
            this.panel2.Controls.Add(this.bunifuSeparator2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 106);
            this.panel2.TabIndex = 15;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(304, 39);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(361, 28);
            this.lblDomicilio.TabIndex = 18;
            this.lblDomicilio.Text = "Domicilio:";
            this.lblDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(304, 11);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(362, 28);
            this.lblNombreCliente.TabIndex = 17;
            this.lblNombreCliente.Text = "Apellido y Nombre:";
            this.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCuitCliente
            // 
            this.lblCuitCliente.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuitCliente.Location = new System.Drawing.Point(5, 13);
            this.lblCuitCliente.Name = "lblCuitCliente";
            this.lblCuitCliente.Size = new System.Drawing.Size(293, 28);
            this.lblCuitCliente.TabIndex = 16;
            this.lblCuitCliente.Text = "CUIT: ";
            this.lblCuitCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(-1, -17);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(668, 35);
            this.bunifuSeparator2.TabIndex = 0;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(284, 61);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(36, 109);
            this.bunifuSeparator1.TabIndex = 14;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // lblCondicionIv
            // 
            this.lblCondicionIv.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicionIv.Location = new System.Drawing.Point(1, 131);
            this.lblCondicionIv.Name = "lblCondicionIv";
            this.lblCondicionIv.Size = new System.Drawing.Size(291, 28);
            this.lblCondicionIv.TabIndex = 13;
            this.lblCondicionIv.Text = "Condicion IVA:";
            this.lblCondicionIv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDomicilioEmpresa
            // 
            this.lblDomicilioEmpresa.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilioEmpresa.Location = new System.Drawing.Point(1, 101);
            this.lblDomicilioEmpresa.Name = "lblDomicilioEmpresa";
            this.lblDomicilioEmpresa.Size = new System.Drawing.Size(291, 28);
            this.lblDomicilioEmpresa.TabIndex = 12;
            this.lblDomicilioEmpresa.Text = "Domicilio Comercial:";
            this.lblDomicilioEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRazonSocialEmpresa
            // 
            this.lblRazonSocialEmpresa.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocialEmpresa.Location = new System.Drawing.Point(1, 73);
            this.lblRazonSocialEmpresa.Name = "lblRazonSocialEmpresa";
            this.lblRazonSocialEmpresa.Size = new System.Drawing.Size(291, 28);
            this.lblRazonSocialEmpresa.TabIndex = 11;
            this.lblRazonSocialEmpresa.Text = "Razon social:";
            this.lblRazonSocialEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Poppins Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(372, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(293, 46);
            this.label6.TabIndex = 10;
            this.label6.Text = "FACTURA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 28);
            this.label5.TabIndex = 9;
            // 
            // lblNumeroComprobante
            // 
            this.lblNumeroComprobante.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblNumeroComprobante.Location = new System.Drawing.Point(344, 38);
            this.lblNumeroComprobante.Name = "lblNumeroComprobante";
            this.lblNumeroComprobante.Size = new System.Drawing.Size(207, 28);
            this.lblNumeroComprobante.TabIndex = 2;
            this.lblNumeroComprobante.Text = "Comp N°: 000001";
            this.lblNumeroComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(368, 74);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(293, 28);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha de emision: 15/03/2019";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCuit
            // 
            this.lblCuit.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuit.Location = new System.Drawing.Point(368, 102);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(293, 28);
            this.lblCuit.TabIndex = 0;
            this.lblCuit.Text = "CUIT: ";
            this.lblCuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTipoComprobante
            // 
            this.pnlTipoComprobante.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlTipoComprobante.Controls.Add(this.lblTipoComprobante);
            this.pnlTipoComprobante.Location = new System.Drawing.Point(280, 12);
            this.pnlTipoComprobante.Name = "pnlTipoComprobante";
            this.pnlTipoComprobante.Size = new System.Drawing.Size(68, 67);
            this.pnlTipoComprobante.TabIndex = 0;
            this.pnlTipoComprobante.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoComprobante.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTipoComprobante.Location = new System.Drawing.Point(14, 8);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(44, 51);
            this.lblTipoComprobante.TabIndex = 0;
            this.lblTipoComprobante.Text = "C";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(294, 16);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pnlBtnImprimir
            // 
            this.pnlBtnImprimir.Controls.Add(this.btnImprimir);
            this.pnlBtnImprimir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtnImprimir.Location = new System.Drawing.Point(0, 491);
            this.pnlBtnImprimir.Name = "pnlBtnImprimir";
            this.pnlBtnImprimir.Size = new System.Drawing.Size(691, 43);
            this.pnlBtnImprimir.TabIndex = 2;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // pnlCerrar
            // 
            this.pnlCerrar.Controls.Add(this.btnCerrar);
            this.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCerrar.Location = new System.Drawing.Point(666, 0);
            this.pnlCerrar.Name = "pnlCerrar";
            this.pnlCerrar.Size = new System.Drawing.Size(25, 491);
            this.pnlCerrar.TabIndex = 3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.Location = new System.Drawing.Point(-4, -2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 31);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // Comprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 534);
            this.Controls.Add(this.pnlCerrar);
            this.Controls.Add(this.pnlBtnImprimir);
            this.Controls.Add(this.pnlTipoComprobante);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Comprobante";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Comprobante_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pnlContenedor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooterRight.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlDescuento.ResumeLayout(false);
            this.pnlDescuento.PerformLayout();
            this.pnlSubtotal.ResumeLayout(false);
            this.pnlSubtotal.PerformLayout();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlTipoComprobante.ResumeLayout(false);
            this.pnlTipoComprobante.PerformLayout();
            this.pnlBtnImprimir.ResumeLayout(false);
            this.pnlCerrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlTipoComprobante;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.Label lblNumeroComprobante;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFooterRight;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Panel pnlSubtotal;
        private System.Windows.Forms.Label lblSubtotalFooter;
        private System.Windows.Forms.Label lblTotalComprobante;
        private System.Windows.Forms.Label lblDescuentoComprobante;
        private System.Windows.Forms.Label lblSubtotalComprobante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel pnlBtnImprimir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblCondicionIv;
        private System.Windows.Forms.Label lblDomicilioEmpresa;
        private System.Windows.Forms.Label lblRazonSocialEmpresa;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblCuitCliente;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Panel pnlCerrar;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrar;
    }
}