namespace Presentacion.Core.Ventas
{
    partial class _00045_Mensaje
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
            this.btnCtaCte = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.Location = new System.Drawing.Point(53, 75);
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.Size = new System.Drawing.Size(114, 36);
            this.btnCtaCte.TabIndex = 0;
            this.btnCtaCte.Text = "Cuenta Corriente";
            this.btnCtaCte.UseVisualStyleBackColor = true;
            this.btnCtaCte.Click += new System.EventHandler(this.btnCtaCte_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.Location = new System.Drawing.Point(210, 75);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(114, 36);
            this.btnEfectivo.TabIndex = 1;
            this.btnEfectivo.Text = "Efectivo";
            this.btnEfectivo.UseVisualStyleBackColor = true;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // _00045_Mensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 319);
            this.Controls.Add(this.btnEfectivo);
            this.Controls.Add(this.btnCtaCte);
            this.MinimumSize = new System.Drawing.Size(398, 169);
            this.Name = "_00045_Mensaje";
            this.Text = "Mensaje";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCtaCte;
        private System.Windows.Forms.Button btnEfectivo;
    }
}