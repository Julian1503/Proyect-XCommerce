namespace Presentacion.Core.Delivery
{
    partial class DeliveryMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pagePedidos = new System.Windows.Forms.TabControl();
            this.tabPendientes = new System.Windows.Forms.TabPage();
            this.tabEnviados = new System.Windows.Forms.TabPage();
            this.flpPendientes = new System.Windows.Forms.FlowLayoutPanel();
            this.flpEnviados = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pagePedidos.SuspendLayout();
            this.tabPendientes.SuspendLayout();
            this.tabEnviados.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(800, 54);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(86, 51);
            this.btnEjecutar.Text = "Nuevo Pedido";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 51);
            this.btnLimpiar.Text = "Todos los Pedidos";
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
            // pagePedidos
            // 
            this.pagePedidos.Controls.Add(this.tabPendientes);
            this.pagePedidos.Controls.Add(this.tabEnviados);
            this.pagePedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePedidos.Location = new System.Drawing.Point(0, 54);
            this.pagePedidos.Name = "pagePedidos";
            this.pagePedidos.SelectedIndex = 0;
            this.pagePedidos.Size = new System.Drawing.Size(800, 396);
            this.pagePedidos.TabIndex = 4;
            this.pagePedidos.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.pagePedidos_Selecting);
            // 
            // tabPendientes
            // 
            this.tabPendientes.Controls.Add(this.flpPendientes);
            this.tabPendientes.Location = new System.Drawing.Point(4, 22);
            this.tabPendientes.Name = "tabPendientes";
            this.tabPendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendientes.Size = new System.Drawing.Size(792, 370);
            this.tabPendientes.TabIndex = 0;
            this.tabPendientes.Text = "Pendientes";
            this.tabPendientes.UseVisualStyleBackColor = true;
            // 
            // tabEnviados
            // 
            this.tabEnviados.Controls.Add(this.flpEnviados);
            this.tabEnviados.Location = new System.Drawing.Point(4, 22);
            this.tabEnviados.Name = "tabEnviados";
            this.tabEnviados.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnviados.Size = new System.Drawing.Size(792, 370);
            this.tabEnviados.TabIndex = 1;
            this.tabEnviados.Text = "Enviados";
            this.tabEnviados.UseVisualStyleBackColor = true;
            // 
            // flpPendientes
            // 
            this.flpPendientes.AutoScroll = true;
            this.flpPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPendientes.Location = new System.Drawing.Point(3, 3);
            this.flpPendientes.Name = "flpPendientes";
            this.flpPendientes.Size = new System.Drawing.Size(786, 364);
            this.flpPendientes.TabIndex = 5;
            // 
            // flpEnviados
            // 
            this.flpEnviados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEnviados.Location = new System.Drawing.Point(3, 3);
            this.flpEnviados.Name = "flpEnviados";
            this.flpEnviados.Size = new System.Drawing.Size(786, 364);
            this.flpEnviados.TabIndex = 0;
            // 
            // DeliveryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pagePedidos);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DeliveryMenu";
            this.Text = "DeliveryMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pagePedidos.ResumeLayout(false);
            this.tabPendientes.ResumeLayout(false);
            this.tabEnviados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEjecutar;
        protected System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.TabControl pagePedidos;
        private System.Windows.Forms.TabPage tabPendientes;
        private System.Windows.Forms.FlowLayoutPanel flpPendientes;
        private System.Windows.Forms.TabPage tabEnviados;
        private System.Windows.Forms.FlowLayoutPanel flpEnviados;
    }
}