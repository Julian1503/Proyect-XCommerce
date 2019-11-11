namespace Presentacion.Core.Ventas.Controladores
{
    partial class CtrolMesa
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
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblPrecioConsumido = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(0, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(100, 70);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecioConsumido
            // 
            this.lblPrecioConsumido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPrecioConsumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioConsumido.ForeColor = System.Drawing.Color.White;
            this.lblPrecioConsumido.Location = new System.Drawing.Point(0, 63);
            this.lblPrecioConsumido.Name = "lblPrecioConsumido";
            this.lblPrecioConsumido.Size = new System.Drawing.Size(100, 37);
            this.lblPrecioConsumido.TabIndex = 1;
            this.lblPrecioConsumido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrolMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.lblPrecioConsumido);
            this.Controls.Add(this.lblNumero);
            this.Name = "CtrolMesa";
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblPrecioConsumido;
    }
}
