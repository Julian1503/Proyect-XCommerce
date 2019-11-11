namespace Presentacion.Core.Venta
{
    partial class _00038_VentaSalon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00038_VentaSalon));
            this.btnNuevaMesa = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnNuevoSalon = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevaMesa
            // 
            this.btnNuevaMesa.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaMesa.Image")));
            this.btnNuevaMesa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevaMesa.Name = "btnNuevaMesa";
            this.btnNuevaMesa.Size = new System.Drawing.Size(76, 51);
            this.btnNuevaMesa.Text = "Nueva Mesa";
            this.btnNuevaMesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevaMesa.Click += new System.EventHandler(this.btnNuevaMesa_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir,
            this.btnNuevoSalon,
            this.btnNuevaMesa});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 54);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // btnNuevoSalon
            // 
            this.btnNuevoSalon.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoSalon.Image")));
            this.btnNuevoSalon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoSalon.Name = "btnNuevoSalon";
            this.btnNuevoSalon.Size = new System.Drawing.Size(78, 51);
            this.btnNuevoSalon.Text = "Nuevo Salon";
            this.btnNuevoSalon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoSalon.Click += new System.EventHandler(this.btnNuevoSalon_Click);
            // 
            // _00038_VentaSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "_00038_VentaSalon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Venta de Salon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnNuevaMesa;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnNuevoSalon;
    }
}