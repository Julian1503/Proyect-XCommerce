namespace Presentacion.Core.Configuracion
{
    partial class Configuracion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbListaKiosco = new System.Windows.Forms.ComboBox();
            this.cmbListaDelivery = new System.Windows.Forms.ComboBox();
            this.btnListas = new System.Windows.Forms.Button();
            this.cmbCadete = new System.Windows.Forms.ComboBox();
            this.cmbMozo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista Delivery";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista Kiosco";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCadete);
            this.panel1.Controls.Add(this.cmbMozo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbListaKiosco);
            this.panel1.Controls.Add(this.cmbListaDelivery);
            this.panel1.Controls.Add(this.btnListas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 193);
            this.panel1.TabIndex = 4;
            // 
            // cmbListaKiosco
            // 
            this.cmbListaKiosco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaKiosco.FormattingEnabled = true;
            this.cmbListaKiosco.Location = new System.Drawing.Point(106, 48);
            this.cmbListaKiosco.Name = "cmbListaKiosco";
            this.cmbListaKiosco.Size = new System.Drawing.Size(121, 21);
            this.cmbListaKiosco.TabIndex = 101;
            // 
            // cmbListaDelivery
            // 
            this.cmbListaDelivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaDelivery.FormattingEnabled = true;
            this.cmbListaDelivery.Location = new System.Drawing.Point(106, 21);
            this.cmbListaDelivery.Name = "cmbListaDelivery";
            this.cmbListaDelivery.Size = new System.Drawing.Size(121, 21);
            this.cmbListaDelivery.TabIndex = 100;
            // 
            // btnListas
            // 
            this.btnListas.Location = new System.Drawing.Point(127, 155);
            this.btnListas.Name = "btnListas";
            this.btnListas.Size = new System.Drawing.Size(75, 23);
            this.btnListas.TabIndex = 4;
            this.btnListas.Text = "Establecer";
            this.btnListas.UseVisualStyleBackColor = true;
            this.btnListas.Click += new System.EventHandler(this.btnListas_Click);
            // 
            // cmbCadete
            // 
            this.cmbCadete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCadete.FormattingEnabled = true;
            this.cmbCadete.Location = new System.Drawing.Point(106, 104);
            this.cmbCadete.Name = "cmbCadete";
            this.cmbCadete.Size = new System.Drawing.Size(121, 21);
            this.cmbCadete.TabIndex = 105;
            // 
            // cmbMozo
            // 
            this.cmbMozo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMozo.FormattingEnabled = true;
            this.cmbMozo.Location = new System.Drawing.Point(106, 77);
            this.cmbMozo.Name = "cmbMozo";
            this.cmbMozo.Size = new System.Drawing.Size(121, 21);
            this.cmbMozo.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Categoria Cadete";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "Categoria Mozo";
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 193);
            this.Controls.Add(this.panel1);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnListas;
        private System.Windows.Forms.ComboBox cmbListaKiosco;
        private System.Windows.Forms.ComboBox cmbListaDelivery;
        private System.Windows.Forms.ComboBox cmbCadete;
        private System.Windows.Forms.ComboBox cmbMozo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}