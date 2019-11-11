namespace Presentacion.Core.Ventas.Controladores
{
    partial class CtrolMesaRedonda
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Circulo = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblPrecioConsumido = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Circulo});
            this.shapeContainer1.Size = new System.Drawing.Size(104, 104);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // Circulo
            // 
            this.Circulo.BackColor = System.Drawing.Color.Red;
            this.Circulo.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.Circulo.Location = new System.Drawing.Point(0, 0);
            this.Circulo.Name = "Circulo";
            this.Circulo.Size = new System.Drawing.Size(100, 100);
            // 
            // lblNumero
            // 
            this.lblNumero.BackColor = System.Drawing.Color.Red;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(24, 13);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(57, 38);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrecioConsumido
            // 
            this.lblPrecioConsumido.BackColor = System.Drawing.Color.Red;
            this.lblPrecioConsumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioConsumido.ForeColor = System.Drawing.Color.White;
            this.lblPrecioConsumido.Location = new System.Drawing.Point(20, 61);
            this.lblPrecioConsumido.Name = "lblPrecioConsumido";
            this.lblPrecioConsumido.Size = new System.Drawing.Size(61, 24);
            this.lblPrecioConsumido.TabIndex = 2;
            this.lblPrecioConsumido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CtrolMesaRedonda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblPrecioConsumido);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "CtrolMesaRedonda";
            this.Size = new System.Drawing.Size(104, 104);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape Circulo;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblPrecioConsumido;
    }
}
