namespace Presentacion.Core.Delivery.Control
{
    partial class ControlPedido
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCadeteDescripcion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalDescrip = new System.Windows.Forms.Label();
            this.lblClienteDescrip = new System.Windows.Forms.Label();
            this.lblDirecDescrip = new System.Windows.Forms.Label();
            this.lblCadete = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.entregarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pbNote = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNote)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.panel1.Location = new System.Drawing.Point(164, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 15);
            this.panel1.TabIndex = 1;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(74, 44);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(95, 24);
            this.lblPedido.TabIndex = 2;
            this.lblPedido.Text = "Pedido N°";
            this.lblPedido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblPedido.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(13, 88);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(65, 18);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(13, 107);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(53, 18);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Direc:";
            this.lblDireccion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblCadeteDescripcion
            // 
            this.lblCadeteDescripcion.AutoSize = true;
            this.lblCadeteDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblCadeteDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadeteDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblCadeteDescripcion.Location = new System.Drawing.Point(75, 126);
            this.lblCadeteDescripcion.Name = "lblCadeteDescripcion";
            this.lblCadeteDescripcion.Size = new System.Drawing.Size(0, 18);
            this.lblCadeteDescripcion.TabIndex = 6;
            this.lblCadeteDescripcion.TextChanged += new System.EventHandler(this.lblClienteDescrip_TextChanged);
            this.lblCadeteDescripcion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(13, 164);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 18);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total:";
            this.lblTotal.Click += new System.EventHandler(this.label2_Click);
            this.lblTotal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblTotalDescrip
            // 
            this.lblTotalDescrip.AutoSize = true;
            this.lblTotalDescrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblTotalDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescrip.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDescrip.Location = new System.Drawing.Point(61, 164);
            this.lblTotalDescrip.Name = "lblTotalDescrip";
            this.lblTotalDescrip.Size = new System.Drawing.Size(0, 18);
            this.lblTotalDescrip.TabIndex = 8;
            this.lblTotalDescrip.TextChanged += new System.EventHandler(this.lblClienteDescrip_TextChanged);
            this.lblTotalDescrip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblClienteDescrip
            // 
            this.lblClienteDescrip.AutoSize = true;
            this.lblClienteDescrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblClienteDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteDescrip.ForeColor = System.Drawing.Color.Black;
            this.lblClienteDescrip.Location = new System.Drawing.Point(75, 88);
            this.lblClienteDescrip.Name = "lblClienteDescrip";
            this.lblClienteDescrip.Size = new System.Drawing.Size(0, 18);
            this.lblClienteDescrip.TabIndex = 9;
            this.lblClienteDescrip.TextChanged += new System.EventHandler(this.lblClienteDescrip_TextChanged);
            this.lblClienteDescrip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblDirecDescrip
            // 
            this.lblDirecDescrip.AutoSize = true;
            this.lblDirecDescrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblDirecDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirecDescrip.ForeColor = System.Drawing.Color.Black;
            this.lblDirecDescrip.Location = new System.Drawing.Point(62, 107);
            this.lblDirecDescrip.Name = "lblDirecDescrip";
            this.lblDirecDescrip.Size = new System.Drawing.Size(0, 18);
            this.lblDirecDescrip.TabIndex = 10;
            this.lblDirecDescrip.TextChanged += new System.EventHandler(this.lblClienteDescrip_TextChanged);
            this.lblDirecDescrip.Click += new System.EventHandler(this.label5_Click);
            this.lblDirecDescrip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // lblCadete
            // 
            this.lblCadete.AutoSize = true;
            this.lblCadete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(175)))));
            this.lblCadete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadete.Location = new System.Drawing.Point(13, 126);
            this.lblCadete.Name = "lblCadete";
            this.lblCadete.Size = new System.Drawing.Size(66, 18);
            this.lblCadete.TabIndex = 5;
            this.lblCadete.Text = "Cadete:";
            this.lblCadete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarMenu,
            this.cancelarMenu,
            this.entregarMenu,
            this.editarMenu});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(181, 114);
            // 
            // enviarMenu
            // 
            this.enviarMenu.Name = "enviarMenu";
            this.enviarMenu.Size = new System.Drawing.Size(180, 22);
            this.enviarMenu.Text = "Enviar";
            // 
            // cancelarMenu
            // 
            this.cancelarMenu.Name = "cancelarMenu";
            this.cancelarMenu.Size = new System.Drawing.Size(180, 22);
            this.cancelarMenu.Text = "Cancelar";
            // 
            // entregarMenu
            // 
            this.entregarMenu.Name = "entregarMenu";
            this.entregarMenu.Size = new System.Drawing.Size(180, 22);
            this.entregarMenu.Text = "Entregar";
            // 
            // editarMenu
            // 
            this.editarMenu.Name = "editarMenu";
            this.editarMenu.Size = new System.Drawing.Size(180, 22);
            this.editarMenu.Text = "Editar";
            // 
            // pbNote
            // 
            this.pbNote.Image = global::Presentacion.Core.Properties.Resources.notes;
            this.pbNote.Location = new System.Drawing.Point(0, 0);
            this.pbNote.Name = "pbNote";
            this.pbNote.Size = new System.Drawing.Size(256, 231);
            this.pbNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNote.TabIndex = 0;
            this.pbNote.TabStop = false;
            this.pbNote.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlPedido_Paint);
            this.pbNote.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbNote_MouseClick);
            // 
            // ControlPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblDirecDescrip);
            this.Controls.Add(this.lblClienteDescrip);
            this.Controls.Add(this.lblTotalDescrip);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCadeteDescripcion);
            this.Controls.Add(this.lblCadete);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbNote);
            this.Name = "ControlPedido";
            this.Size = new System.Drawing.Size(256, 231);
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCadeteDescripcion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalDescrip;
        private System.Windows.Forms.Label lblClienteDescrip;
        private System.Windows.Forms.Label lblDirecDescrip;
        private System.Windows.Forms.Label lblCadete;
        private System.Windows.Forms.PictureBox pbNote;
        private System.Windows.Forms.ToolStripMenuItem enviarMenu;
        private System.Windows.Forms.ToolStripMenuItem cancelarMenu;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem entregarMenu;
        private System.Windows.Forms.ToolStripMenuItem editarMenu;
    }
}
