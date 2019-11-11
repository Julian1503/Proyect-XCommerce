namespace Presentacion.Core.Ventas.Controladores
{
    partial class CtrolBase
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fueraServicioMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sacarFueraServicioMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarReservaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarVentaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirMenu,
            this.cerrarMenu,
            this.reservaMenu,
            this.fueraServicioMenu,
            this.sacarFueraServicioMenu,
            this.cancelarReservaMenu,
            this.cancelarVentaMenu});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(211, 180);
            // 
            // abrirMenu
            // 
            this.abrirMenu.Name = "abrirMenu";
            this.abrirMenu.Size = new System.Drawing.Size(210, 22);
            this.abrirMenu.Text = "Abrir Mesa";
            // 
            // cerrarMenu
            // 
            this.cerrarMenu.Name = "cerrarMenu";
            this.cerrarMenu.Size = new System.Drawing.Size(210, 22);
            this.cerrarMenu.Text = "Cerrar Mesa";
            this.cerrarMenu.Click += new System.EventHandler(this.cerrarMenu_Click);
            // 
            // reservaMenu
            // 
            this.reservaMenu.Name = "reservaMenu";
            this.reservaMenu.Size = new System.Drawing.Size(210, 22);
            this.reservaMenu.Text = "Reservar Mesa";
            this.reservaMenu.Click += new System.EventHandler(this.reservaMenu_Click);
            // 
            // fueraServicioMenu
            // 
            this.fueraServicioMenu.Name = "fueraServicioMenu";
            this.fueraServicioMenu.Size = new System.Drawing.Size(210, 22);
            this.fueraServicioMenu.Text = "Fuera de Servicio";
            this.fueraServicioMenu.Click += new System.EventHandler(this.fueraServicioMenu_Click);
            // 
            // sacarFueraServicioMenu
            // 
            this.sacarFueraServicioMenu.Name = "sacarFueraServicioMenu";
            this.sacarFueraServicioMenu.Size = new System.Drawing.Size(210, 22);
            this.sacarFueraServicioMenu.Text = "Sacar de Fuera de Servicio";
            this.sacarFueraServicioMenu.Click += new System.EventHandler(this.sacarFueraServicioMenu_Click);
            // 
            // cancelarReservaMenu
            // 
            this.cancelarReservaMenu.Name = "cancelarReservaMenu";
            this.cancelarReservaMenu.Size = new System.Drawing.Size(210, 22);
            this.cancelarReservaMenu.Text = "Cancelar Reserva";
            this.cancelarReservaMenu.Click += new System.EventHandler(this.cancelarReservaMenu_Click);
            // 
            // cancelarVentaMenu
            // 
            this.cancelarVentaMenu.Name = "cancelarVentaMenu";
            this.cancelarVentaMenu.Size = new System.Drawing.Size(210, 22);
            this.cancelarVentaMenu.Text = "Cancelar Venta";
            this.cancelarVentaMenu.Click += new System.EventHandler(this.cancelarVentaMenu_Click_1);
            // 
            // CtrolBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.menu;
            this.Name = "CtrolBase";
            this.Size = new System.Drawing.Size(100, 100);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.ToolStripMenuItem sacarFueraServicioMenu;
        protected System.Windows.Forms.ContextMenuStrip menu;
        protected System.Windows.Forms.ToolStripMenuItem abrirMenu;
        protected System.Windows.Forms.ToolStripMenuItem cerrarMenu;
        protected System.Windows.Forms.ToolStripMenuItem reservaMenu;
        protected System.Windows.Forms.ToolStripMenuItem fueraServicioMenu;
        protected System.Windows.Forms.ToolStripMenuItem cancelarReservaMenu;
        protected System.Windows.Forms.ToolStripMenuItem cancelarVentaMenu;
    }
}
