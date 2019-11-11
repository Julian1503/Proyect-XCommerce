namespace Presentacion.Core.Caja
{
    partial class _00011_Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00011_Caja));
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbrirCaja.BackgroundImage")));
            this.btnAbrirCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAbrirCaja.Location = new System.Drawing.Point(40, 33);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(196, 271);
            this.btnAbrirCaja.TabIndex = 0;
            this.btnAbrirCaja.UseVisualStyleBackColor = true;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarCaja.BackgroundImage")));
            this.btnCerrarCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarCaja.Location = new System.Drawing.Point(289, 33);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(196, 271);
            this.btnCerrarCaja.TabIndex = 1;
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // _00011_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 339);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.btnAbrirCaja);
            this.Name = "_00011_Caja";
            this.Text = "_00011_Caja";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Button btnCerrarCaja;
    }
}