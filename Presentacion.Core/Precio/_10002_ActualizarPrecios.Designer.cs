namespace Presentacion.Core.Precio
{
    partial class _10002_ActualizarPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_10002_ActualizarPrecios));
            this.lblProducto = new System.Windows.Forms.Label();
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.nudPrecioPublico = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioPublico = new System.Windows.Forms.Label();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.nudPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnAgregarLista = new System.Windows.Forms.Button();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cbActivarHora = new System.Windows.Forms.CheckBox();
            this.pnlHora = new System.Windows.Forms.Panel();
            this.lblHoraVenta = new System.Windows.Forms.Label();
            this.dtpHoraVenta = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPublico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).BeginInit();
            this.pnlHora.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProducto
            // 
            this.lblProducto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(42, 86);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Producto";
            // 
            // cmbLista
            // 
            this.cmbLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(390, 79);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(150, 21);
            this.cmbLista.TabIndex = 2;
            this.cmbLista.SelectionChangeCommitted += new System.EventHandler(this.cmbLista_SelectionChangeCommitted);
            // 
            // lblLista
            // 
            this.lblLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(307, 83);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(82, 13);
            this.lblLista.TabIndex = 3;
            this.lblLista.Text = "Lista de Precios";
            // 
            // nudPrecioPublico
            // 
            this.nudPrecioPublico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nudPrecioPublico.DecimalPlaces = 2;
            this.nudPrecioPublico.Location = new System.Drawing.Point(98, 133);
            this.nudPrecioPublico.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nudPrecioPublico.Name = "nudPrecioPublico";
            this.nudPrecioPublico.Size = new System.Drawing.Size(186, 20);
            this.nudPrecioPublico.TabIndex = 4;
            this.nudPrecioPublico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrecioPublico.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblPrecioPublico
            // 
            this.lblPrecioPublico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPrecioPublico.AutoSize = true;
            this.lblPrecioPublico.Location = new System.Drawing.Point(6, 135);
            this.lblPrecioPublico.Name = "lblPrecioPublico";
            this.lblPrecioPublico.Size = new System.Drawing.Size(86, 13);
            this.lblPrecioPublico.TabIndex = 5;
            this.lblPrecioPublico.Text = "Precio al Publico";
            // 
            // lblPrecioCosto
            // 
            this.lblPrecioCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Location = new System.Drawing.Point(307, 135);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(82, 13);
            this.lblPrecioCosto.TabIndex = 7;
            this.lblPrecioCosto.Text = "Precio de Costo";
            // 
            // nudPrecioCosto
            // 
            this.nudPrecioCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nudPrecioCosto.DecimalPlaces = 2;
            this.nudPrecioCosto.Location = new System.Drawing.Point(390, 133);
            this.nudPrecioCosto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nudPrecioCosto.Name = "nudPrecioCosto";
            this.nudPrecioCosto.Size = new System.Drawing.Size(186, 20);
            this.nudPrecioCosto.TabIndex = 6;
            this.nudPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrecioCosto.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudPrecioCosto.ValueChanged += new System.EventHandler(this.nudPrecioCosto_ValueChanged);
            this.nudPrecioCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudPrecioCosto_KeyPress);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregarProducto.Location = new System.Drawing.Point(254, 79);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(30, 21);
            this.btnAgregarProducto.TabIndex = 8;
            this.btnAgregarProducto.Text = "...";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnAgregarLista
            // 
            this.btnAgregarLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregarLista.Location = new System.Drawing.Point(546, 79);
            this.btnAgregarLista.Name = "btnAgregarLista";
            this.btnAgregarLista.Size = new System.Drawing.Size(30, 21);
            this.btnAgregarLista.TabIndex = 9;
            this.btnAgregarLista.Text = "...";
            this.btnAgregarLista.UseVisualStyleBackColor = true;
            this.btnAgregarLista.Click += new System.EventHandler(this.btnAgregarLista_Click);
            // 
            // cmbProducto
            // 
            this.cmbProducto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(98, 79);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(150, 21);
            this.cmbProducto.TabIndex = 10;
            // 
            // cbActivarHora
            // 
            this.cbActivarHora.AutoSize = true;
            this.cbActivarHora.Location = new System.Drawing.Point(12, 29);
            this.cbActivarHora.Name = "cbActivarHora";
            this.cbActivarHora.Size = new System.Drawing.Size(131, 17);
            this.cbActivarHora.TabIndex = 11;
            this.cbActivarHora.Text = "Activar Hora de Venta";
            this.cbActivarHora.UseVisualStyleBackColor = true;
            this.cbActivarHora.CheckedChanged += new System.EventHandler(this.cbActivarHora_CheckedChanged);
            // 
            // pnlHora
            // 
            this.pnlHora.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlHora.BackColor = System.Drawing.Color.Silver;
            this.pnlHora.Controls.Add(this.lblHoraVenta);
            this.pnlHora.Controls.Add(this.dtpHoraVenta);
            this.pnlHora.Controls.Add(this.cbActivarHora);
            this.pnlHora.Location = new System.Drawing.Point(132, 187);
            this.pnlHora.Name = "pnlHora";
            this.pnlHora.Size = new System.Drawing.Size(385, 71);
            this.pnlHora.TabIndex = 12;
            // 
            // lblHoraVenta
            // 
            this.lblHoraVenta.AutoSize = true;
            this.lblHoraVenta.Enabled = false;
            this.lblHoraVenta.Location = new System.Drawing.Point(196, 29);
            this.lblHoraVenta.Name = "lblHoraVenta";
            this.lblHoraVenta.Size = new System.Drawing.Size(75, 13);
            this.lblHoraVenta.TabIndex = 13;
            this.lblHoraVenta.Text = "Hora de venta";
            // 
            // dtpHoraVenta
            // 
            this.dtpHoraVenta.Enabled = false;
            this.dtpHoraVenta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraVenta.Location = new System.Drawing.Point(277, 26);
            this.dtpHoraVenta.Name = "dtpHoraVenta";
            this.dtpHoraVenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpHoraVenta.Size = new System.Drawing.Size(95, 20);
            this.dtpHoraVenta.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEjecutar,
            this.btnLimpiar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(596, 54);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(53, 51);
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(51, 51);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(36, 51);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // _10002_ActualizarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 274);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlHora);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.btnAgregarLista);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.lblPrecioCosto);
            this.Controls.Add(this.nudPrecioCosto);
            this.Controls.Add(this.lblPrecioPublico);
            this.Controls.Add(this.nudPrecioPublico);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.cmbLista);
            this.Controls.Add(this.lblProducto);
            this.Name = "_10002_ActualizarPrecios";
            this.Text = "Actualizar Precios";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPublico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).EndInit();
            this.pnlHora.ResumeLayout(false);
            this.pnlHora.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbLista;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.NumericUpDown nudPrecioPublico;
        private System.Windows.Forms.Label lblPrecioPublico;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.NumericUpDown nudPrecioCosto;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnAgregarLista;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.CheckBox cbActivarHora;
        private System.Windows.Forms.Panel pnlHora;
        private System.Windows.Forms.Label lblHoraVenta;
        private System.Windows.Forms.DateTimePicker dtpHoraVenta;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEjecutar;
        protected System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
    }
}