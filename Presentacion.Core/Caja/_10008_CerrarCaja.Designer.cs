namespace Presentacion.Core.Caja
{
    partial class _10008_CerrarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_10008_CerrarCaja));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nudMontoCierre = new System.Windows.Forms.NumericUpDown();
            this.lblMontoCierre = new System.Windows.Forms.Label();
            this.lblMontoSistema = new System.Windows.Forms.Label();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.txtMontoSistema = new System.Windows.Forms.TextBox();
            this.lblResumen = new System.Windows.Forms.Label();
            this.menuAccesoRapido = new System.Windows.Forms.ToolStrip();
            this.btnCerrarCaja = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCierre)).BeginInit();
            this.menuAccesoRapido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMontoCierre
            // 
            this.nudMontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoCierre.Location = new System.Drawing.Point(266, 69);
            this.nudMontoCierre.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudMontoCierre.Name = "nudMontoCierre";
            this.nudMontoCierre.Size = new System.Drawing.Size(120, 26);
            this.nudMontoCierre.TabIndex = 5;
            this.nudMontoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoCierre.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudMontoCierre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMontoCierre_KeyPress);
            // 
            // lblMontoCierre
            // 
            this.lblMontoCierre.AutoSize = true;
            this.lblMontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoCierre.Location = new System.Drawing.Point(148, 71);
            this.lblMontoCierre.Name = "lblMontoCierre";
            this.lblMontoCierre.Size = new System.Drawing.Size(112, 20);
            this.lblMontoCierre.TabIndex = 6;
            this.lblMontoCierre.Text = "Monto Cierre";
            // 
            // lblMontoSistema
            // 
            this.lblMontoSistema.AutoSize = true;
            this.lblMontoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSistema.Location = new System.Drawing.Point(390, 118);
            this.lblMontoSistema.Name = "lblMontoSistema";
            this.lblMontoSistema.Size = new System.Drawing.Size(129, 20);
            this.lblMontoSistema.TabIndex = 8;
            this.lblMontoSistema.Text = "Monto Sistema";
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Location = new System.Drawing.Point(428, 72);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(91, 20);
            this.lblDiferencia.TabIndex = 10;
            this.lblDiferencia.Text = "Diferencia";
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.Enabled = false;
            this.txtDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferencia.Location = new System.Drawing.Point(525, 69);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.Size = new System.Drawing.Size(134, 26);
            this.txtDiferencia.TabIndex = 11;
            // 
            // txtMontoSistema
            // 
            this.txtMontoSistema.Enabled = false;
            this.txtMontoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoSistema.Location = new System.Drawing.Point(525, 115);
            this.txtMontoSistema.Name = "txtMontoSistema";
            this.txtMontoSistema.Size = new System.Drawing.Size(134, 26);
            this.txtMontoSistema.TabIndex = 12;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.Location = new System.Drawing.Point(32, 139);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(85, 20);
            this.lblResumen.TabIndex = 13;
            this.lblResumen.Text = "Resumen";
            // 
            // menuAccesoRapido
            // 
            this.menuAccesoRapido.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuAccesoRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrarCaja,
            this.btnSalir});
            this.menuAccesoRapido.Location = new System.Drawing.Point(0, 0);
            this.menuAccesoRapido.Name = "menuAccesoRapido";
            this.menuAccesoRapido.Size = new System.Drawing.Size(734, 54);
            this.menuAccesoRapido.TabIndex = 15;
            this.menuAccesoRapido.Text = "toolStrip1";
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarCaja.Image")));
            this.btnCerrarCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(69, 51);
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrar_Click);
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
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGrilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrilla.Location = new System.Drawing.Point(36, 162);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(654, 458);
            this.dgvGrilla.TabIndex = 16;
            this.dgvGrilla.TabStop = false;
            // 
            // _10008_CerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 651);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.menuAccesoRapido);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.txtMontoSistema);
            this.Controls.Add(this.txtDiferencia);
            this.Controls.Add(this.lblDiferencia);
            this.Controls.Add(this.lblMontoSistema);
            this.Controls.Add(this.lblMontoCierre);
            this.Controls.Add(this.nudMontoCierre);
            this.Name = "_10008_CerrarCaja";
            this.Text = "Cerrar Caja";
            this.Load += new System.EventHandler(this._10008_CerrarCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCierre)).EndInit();
            this.menuAccesoRapido.ResumeLayout(false);
            this.menuAccesoRapido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudMontoCierre;
        private System.Windows.Forms.Label lblMontoCierre;
        private System.Windows.Forms.Label lblMontoSistema;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.TextBox txtMontoSistema;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.ToolStrip menuAccesoRapido;
        private System.Windows.Forms.ToolStripButton btnCerrarCaja;
        private System.Windows.Forms.ToolStripButton btnSalir;
        protected System.Windows.Forms.DataGridView dgvGrilla;
    }
}