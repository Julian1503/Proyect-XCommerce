namespace Presentacion.Core.Reserva
{
    partial class _00030_ABM_Reserva
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
            this.lblSenia = new System.Windows.Forms.Label();
            this.lblEstadoReserva = new System.Windows.Forms.Label();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.lblMotivoReserva = new System.Windows.Forms.Label();
            this.cmbMotivoReserva = new System.Windows.Forms.ComboBox();
            this.cmbEstadoReserva = new System.Windows.Forms.ComboBox();
            this.nudSenia = new System.Windows.Forms.NumericUpDown();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnAgregarMesa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMesa = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSenia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSenia
            // 
            this.lblSenia.AutoSize = true;
            this.lblSenia.Location = new System.Drawing.Point(73, 86);
            this.lblSenia.Name = "lblSenia";
            this.lblSenia.Size = new System.Drawing.Size(32, 13);
            this.lblSenia.TabIndex = 39;
            this.lblSenia.Text = "Seña";
            // 
            // lblEstadoReserva
            // 
            this.lblEstadoReserva.AutoSize = true;
            this.lblEstadoReserva.Location = new System.Drawing.Point(7, 109);
            this.lblEstadoReserva.Name = "lblEstadoReserva";
            this.lblEstadoReserva.Size = new System.Drawing.Size(98, 13);
            this.lblEstadoReserva.TabIndex = 40;
            this.lblEstadoReserva.Text = "Estado de Reserva";
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.Location = new System.Drawing.Point(304, 135);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(30, 21);
            this.btnNuevaReserva.TabIndex = 7;
            this.btnNuevaReserva.Text = "...";
            this.btnNuevaReserva.UseVisualStyleBackColor = true;
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            // 
            // lblMotivoReserva
            // 
            this.lblMotivoReserva.AutoSize = true;
            this.lblMotivoReserva.Location = new System.Drawing.Point(23, 139);
            this.lblMotivoReserva.Name = "lblMotivoReserva";
            this.lblMotivoReserva.Size = new System.Drawing.Size(82, 13);
            this.lblMotivoReserva.TabIndex = 60;
            this.lblMotivoReserva.Text = "Motivo Reserva";
            // 
            // cmbMotivoReserva
            // 
            this.cmbMotivoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivoReserva.FormattingEnabled = true;
            this.cmbMotivoReserva.Location = new System.Drawing.Point(111, 136);
            this.cmbMotivoReserva.Name = "cmbMotivoReserva";
            this.cmbMotivoReserva.Size = new System.Drawing.Size(187, 21);
            this.cmbMotivoReserva.TabIndex = 3;
            // 
            // cmbEstadoReserva
            // 
            this.cmbEstadoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoReserva.FormattingEnabled = true;
            this.cmbEstadoReserva.Items.AddRange(new object[] {
            "Confirmada",
            "No Confirmada",
            "Cancelada"});
            this.cmbEstadoReserva.Location = new System.Drawing.Point(111, 110);
            this.cmbEstadoReserva.Name = "cmbEstadoReserva";
            this.cmbEstadoReserva.Size = new System.Drawing.Size(223, 21);
            this.cmbEstadoReserva.TabIndex = 2;
            // 
            // nudSenia
            // 
            this.nudSenia.Location = new System.Drawing.Point(111, 85);
            this.nudSenia.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudSenia.Name = "nudSenia";
            this.nudSenia.Size = new System.Drawing.Size(223, 20);
            this.nudSenia.TabIndex = 1;
            this.nudSenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(62, 192);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 65;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(66, 166);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 68;
            this.lblCliente.Text = "Cliente";
            // 
            // btnAgregarMesa
            // 
            this.btnAgregarMesa.Location = new System.Drawing.Point(304, 214);
            this.btnAgregarMesa.Name = "btnAgregarMesa";
            this.btnAgregarMesa.Size = new System.Drawing.Size(30, 23);
            this.btnAgregarMesa.TabIndex = 10;
            this.btnAgregarMesa.Text = "...";
            this.btnAgregarMesa.UseVisualStyleBackColor = true;
            this.btnAgregarMesa.Click += new System.EventHandler(this.btnAgregarMesa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Mesa";
            // 
            // cmbMesa
            // 
            this.cmbMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesa.FormattingEnabled = true;
            this.cmbMesa.Location = new System.Drawing.Point(111, 217);
            this.cmbMesa.Name = "cmbMesa";
            this.cmbMesa.Size = new System.Drawing.Size(187, 21);
            this.cmbMesa.TabIndex = 6;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(111, 163);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(223, 20);
            this.txtCliente.TabIndex = 72;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(111, 189);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(223, 20);
            this.txtUsuario.TabIndex = 73;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(340, 219);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 20);
            this.label24.TabIndex = 87;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(261, 277);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(116, 13);
            this.label25.TabIndex = 86;
            this.label25.Text = "Campos Obligatorios (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(340, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 88;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(340, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(340, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(340, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 92;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(340, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 91;
            this.label6.Text = "*";
            // 
            // _00030_ABM_Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 299);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnAgregarMesa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMesa);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.nudSenia);
            this.Controls.Add(this.cmbEstadoReserva);
            this.Controls.Add(this.btnNuevaReserva);
            this.Controls.Add(this.lblMotivoReserva);
            this.Controls.Add(this.cmbMotivoReserva);
            this.Controls.Add(this.lblEstadoReserva);
            this.Controls.Add(this.lblSenia);
            this.Name = "_00030_ABM_Reserva";
            this.Text = "Reserva (Alta, Baja, Modificacion)";
            this.Controls.SetChildIndex(this.lblSenia, 0);
            this.Controls.SetChildIndex(this.lblEstadoReserva, 0);
            this.Controls.SetChildIndex(this.cmbMotivoReserva, 0);
            this.Controls.SetChildIndex(this.lblMotivoReserva, 0);
            this.Controls.SetChildIndex(this.btnNuevaReserva, 0);
            this.Controls.SetChildIndex(this.cmbEstadoReserva, 0);
            this.Controls.SetChildIndex(this.nudSenia, 0);
            this.Controls.SetChildIndex(this.lblUsuario, 0);
            this.Controls.SetChildIndex(this.lblCliente, 0);
            this.Controls.SetChildIndex(this.cmbMesa, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnAgregarMesa, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSenia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSenia;
        private System.Windows.Forms.Label lblEstadoReserva;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Label lblMotivoReserva;
        private System.Windows.Forms.ComboBox cmbMotivoReserva;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Button btnAgregarMesa;
        protected System.Windows.Forms.ComboBox cmbMesa;
        protected System.Windows.Forms.ComboBox cmbEstadoReserva;
        protected System.Windows.Forms.NumericUpDown nudSenia;
    }
}