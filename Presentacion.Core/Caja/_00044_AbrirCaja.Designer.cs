namespace Presentacion.Core.Caja
{
    partial class _00044_AbrirCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00044_AbrirCaja));
            this.menuAccesoRapido = new System.Windows.Forms.ToolStrip();
            this.btnAbrirCaja = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.menuAccesoRapido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // menuAccesoRapido
            // 
            this.menuAccesoRapido.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuAccesoRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrirCaja,
            this.btnSalir});
            this.menuAccesoRapido.Location = new System.Drawing.Point(0, 0);
            this.menuAccesoRapido.Name = "menuAccesoRapido";
            this.menuAccesoRapido.Size = new System.Drawing.Size(326, 54);
            this.menuAccesoRapido.TabIndex = 2;
            this.menuAccesoRapido.Text = "toolStrip1";
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirCaja.Image")));
            this.btnAbrirCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(63, 51);
            this.btnAbrirCaja.Text = "Abrir Caja";
            this.btnAbrirCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monto Apertura";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(63, 144);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(112, 141);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(169, 20);
            this.txtUsuario.TabIndex = 6;
            // 
            // nudMonto
            // 
            this.nudMonto.Location = new System.Drawing.Point(112, 103);
            this.nudMonto.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(169, 20);
            this.nudMonto.TabIndex = 7;
            // 
            // _00044_AbrirCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 212);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuAccesoRapido);
            this.Name = "_00044_AbrirCaja";
            this.Text = "Abrir Caja";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.menuAccesoRapido.ResumeLayout(false);
            this.menuAccesoRapido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuAccesoRapido;
        private System.Windows.Forms.ToolStripButton btnAbrirCaja;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.NumericUpDown nudMonto;
    }
}