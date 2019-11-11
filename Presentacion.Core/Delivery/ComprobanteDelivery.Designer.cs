namespace Presentacion.Core.Delivery
{
    partial class ComprobanteDelivery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprobanteDelivery));
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.nudSubTotal = new System.Windows.Forms.NumericUpDown();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPagar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlMozo = new System.Windows.Forms.Panel();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.lblCasa = new System.Windows.Forms.Label();
            this.lblMzana = new System.Windows.Forms.Label();
            this.txtCasa = new System.Windows.Forms.TextBox();
            this.txtManz = new System.Windows.Forms.TextBox();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.lblDpto = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMozo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtCadete = new System.Windows.Forms.TextBox();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblCantidadProducto = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.lblCodigos = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCodigos = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlMozo.SuspendLayout();
            this.pnlProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Enabled = false;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(618, 638);
            this.nudTotal.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(170, 31);
            this.nudTotal.TabIndex = 2;
            this.nudTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(525, 640);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(85, 25);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "TOTAL";
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Location = new System.Drawing.Point(618, 601);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(170, 31);
            this.nudDescuento.TabIndex = 1;
            this.nudDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDescuento_KeyPress);
            this.nudDescuento.Leave += new System.EventHandler(this.nudDescuento_Leave);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Enabled = false;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(447, 603);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(165, 25);
            this.lblDescuento.TabIndex = 15;
            this.lblDescuento.Text = "Descuento [%]";
            // 
            // nudSubTotal
            // 
            this.nudSubTotal.DecimalPlaces = 2;
            this.nudSubTotal.Enabled = false;
            this.nudSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubTotal.Location = new System.Drawing.Point(618, 564);
            this.nudSubTotal.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudSubTotal.Name = "nudSubTotal";
            this.nudSubTotal.Size = new System.Drawing.Size(170, 31);
            this.nudSubTotal.TabIndex = 0;
            this.nudSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(496, 570);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(114, 25);
            this.lblSubTotal.TabIndex = 13;
            this.lblSubTotal.Text = "Sub-Total";
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 237);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(802, 312);
            this.dgvGrilla.TabIndex = 11;
            this.dgvGrilla.TabStop = false;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGrilla_RowEnter);
            this.dgvGrilla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvGrilla_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPagar,
            this.btnEliminar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 54);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPagar
            // 
            this.btnPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Image")));
            this.btnPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(91, 51);
            this.btnPagar.Text = "Realizar pedido";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(106, 51);
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            // pnlMozo
            // 
            this.pnlMozo.Controls.Add(this.lblLote);
            this.pnlMozo.Controls.Add(this.txtLote);
            this.pnlMozo.Controls.Add(this.lblCasa);
            this.pnlMozo.Controls.Add(this.lblMzana);
            this.pnlMozo.Controls.Add(this.txtCasa);
            this.pnlMozo.Controls.Add(this.txtManz);
            this.pnlMozo.Controls.Add(this.lblBarrio);
            this.pnlMozo.Controls.Add(this.txtBarrio);
            this.pnlMozo.Controls.Add(this.lblPiso);
            this.pnlMozo.Controls.Add(this.txtPiso);
            this.pnlMozo.Controls.Add(this.lblDpto);
            this.pnlMozo.Controls.Add(this.lblNumero);
            this.pnlMozo.Controls.Add(this.txtDpto);
            this.pnlMozo.Controls.Add(this.lblDireccion);
            this.pnlMozo.Controls.Add(this.txtNumero);
            this.pnlMozo.Controls.Add(this.txtCalle);
            this.pnlMozo.Controls.Add(this.btnCliente);
            this.pnlMozo.Controls.Add(this.lblCliente);
            this.pnlMozo.Controls.Add(this.txtCliente);
            this.pnlMozo.Controls.Add(this.btnBuscar);
            this.pnlMozo.Controls.Add(this.lblMozo);
            this.pnlMozo.Controls.Add(this.txtLegajo);
            this.pnlMozo.Controls.Add(this.txtCadete);
            this.pnlMozo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMozo.Location = new System.Drawing.Point(0, 110);
            this.pnlMozo.Name = "pnlMozo";
            this.pnlMozo.Size = new System.Drawing.Size(802, 126);
            this.pnlMozo.TabIndex = 22;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(470, 92);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(28, 13);
            this.lblLote.TabIndex = 30;
            this.lblLote.Text = "Lote";
            // 
            // txtLote
            // 
            this.txtLote.Enabled = false;
            this.txtLote.Location = new System.Drawing.Point(501, 89);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(72, 20);
            this.txtLote.TabIndex = 9;
            // 
            // lblCasa
            // 
            this.lblCasa.AutoSize = true;
            this.lblCasa.Location = new System.Drawing.Point(581, 92);
            this.lblCasa.Name = "lblCasa";
            this.lblCasa.Size = new System.Drawing.Size(31, 13);
            this.lblCasa.TabIndex = 28;
            this.lblCasa.Text = "Casa";
            // 
            // lblMzana
            // 
            this.lblMzana.AutoSize = true;
            this.lblMzana.Location = new System.Drawing.Point(343, 92);
            this.lblMzana.Name = "lblMzana";
            this.lblMzana.Size = new System.Drawing.Size(36, 13);
            this.lblMzana.TabIndex = 27;
            this.lblMzana.Text = "Manz.";
            // 
            // txtCasa
            // 
            this.txtCasa.Enabled = false;
            this.txtCasa.Location = new System.Drawing.Point(618, 89);
            this.txtCasa.Name = "txtCasa";
            this.txtCasa.Size = new System.Drawing.Size(72, 20);
            this.txtCasa.TabIndex = 10;
            // 
            // txtManz
            // 
            this.txtManz.Enabled = false;
            this.txtManz.Location = new System.Drawing.Point(385, 89);
            this.txtManz.Name = "txtManz";
            this.txtManz.Size = new System.Drawing.Size(76, 20);
            this.txtManz.TabIndex = 8;
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(30, 92);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(34, 13);
            this.lblBarrio.TabIndex = 24;
            this.lblBarrio.Text = "Barrio";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Enabled = false;
            this.txtBarrio.Location = new System.Drawing.Point(76, 89);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(253, 20);
            this.txtBarrio.TabIndex = 7;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(470, 66);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(27, 13);
            this.lblPiso.TabIndex = 21;
            this.lblPiso.Text = "Piso";
            // 
            // txtPiso
            // 
            this.txtPiso.Enabled = false;
            this.txtPiso.Location = new System.Drawing.Point(501, 63);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(72, 20);
            this.txtPiso.TabIndex = 5;
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Location = new System.Drawing.Point(581, 66);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(33, 13);
            this.lblDpto.TabIndex = 19;
            this.lblDpto.Text = "Dpto.";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(335, 66);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 18;
            this.lblNumero.Text = "Numero";
            // 
            // txtDpto
            // 
            this.txtDpto.Enabled = false;
            this.txtDpto.Location = new System.Drawing.Point(618, 63);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(72, 20);
            this.txtDpto.TabIndex = 6;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(34, 66);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(30, 13);
            this.lblDireccion.TabIndex = 16;
            this.lblDireccion.Text = "Calle";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(385, 63);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(76, 20);
            this.txtNumero.TabIndex = 4;
            // 
            // txtCalle
            // 
            this.txtCalle.Enabled = false;
            this.txtCalle.Location = new System.Drawing.Point(76, 63);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(253, 20);
            this.txtCalle.TabIndex = 3;
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(713, 9);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCliente.TabIndex = 12;
            this.btnCliente.Text = "Buscar";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(25, 39);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 12;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(76, 36);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(631, 20);
            this.txtCliente.TabIndex = 2;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(713, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // lblMozo
            // 
            this.lblMozo.AutoSize = true;
            this.lblMozo.Location = new System.Drawing.Point(23, 13);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(41, 13);
            this.lblMozo.TabIndex = 7;
            this.lblMozo.Text = "Cadete";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(76, 10);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(100, 20);
            this.txtLegajo.TabIndex = 0;
            this.txtLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLegajo_KeyPress);
            // 
            // txtCadete
            // 
            this.txtCadete.Enabled = false;
            this.txtCadete.Location = new System.Drawing.Point(192, 10);
            this.txtCadete.Name = "txtCadete";
            this.txtCadete.Size = new System.Drawing.Size(515, 20);
            this.txtCadete.TabIndex = 1;
            // 
            // pnlProducto
            // 
            this.pnlProducto.Controls.Add(this.btnAgregar);
            this.pnlProducto.Controls.Add(this.lblCantidadProducto);
            this.pnlProducto.Controls.Add(this.lblDescripcion);
            this.pnlProducto.Controls.Add(this.lblPrecioUnitario);
            this.pnlProducto.Controls.Add(this.lblCodigos);
            this.pnlProducto.Controls.Add(this.txtDescripcion);
            this.pnlProducto.Controls.Add(this.txtPrecio);
            this.pnlProducto.Controls.Add(this.txtCodigos);
            this.pnlProducto.Controls.Add(this.nudCantidad);
            this.pnlProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProducto.Location = new System.Drawing.Point(0, 54);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(802, 56);
            this.pnlProducto.TabIndex = 21;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(713, 16);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Enter += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // lblCantidadProducto
            // 
            this.lblCantidadProducto.AutoSize = true;
            this.lblCantidadProducto.Location = new System.Drawing.Point(602, 3);
            this.lblCantidadProducto.Name = "lblCantidadProducto";
            this.lblCantidadProducto.Size = new System.Drawing.Size(49, 13);
            this.lblCantidadProducto.TabIndex = 8;
            this.lblCantidadProducto.Text = "Cantidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(155, 3);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(486, 3);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(76, 13);
            this.lblPrecioUnitario.TabIndex = 6;
            this.lblPrecioUnitario.Text = "Precio Unitario";
            // 
            // lblCodigos
            // 
            this.lblCodigos.AutoSize = true;
            this.lblCodigos.Location = new System.Drawing.Point(9, 3);
            this.lblCodigos.Name = "lblCodigos";
            this.lblCodigos.Size = new System.Drawing.Size(126, 13);
            this.lblCodigos.TabIndex = 0;
            this.lblCodigos.Text = "Codigo/Codigo de Barras";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(158, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(317, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(489, 19);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 2;
            // 
            // txtCodigos
            // 
            this.txtCodigos.Location = new System.Drawing.Point(12, 19);
            this.txtCodigos.Name = "txtCodigos";
            this.txtCodigos.Size = new System.Drawing.Size(123, 20);
            this.txtCodigos.TabIndex = 0;
            this.txtCodigos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigos_KeyPress);
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Location = new System.Drawing.Point(595, 19);
            this.nudCantidad.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(112, 20);
            this.nudCantidad.TabIndex = 3;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ComprobanteDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 683);
            this.Controls.Add(this.pnlMozo);
            this.Controls.Add(this.pnlProducto);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.nudSubTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "ComprobanteDelivery";
            this.Text = "ComprobanteDelivery";
            this.Load += new System.EventHandler(this.ComprobanteDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlMozo.ResumeLayout(false);
            this.pnlMozo.PerformLayout();
            this.pnlProducto.ResumeLayout(false);
            this.pnlProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.NumericUpDown nudSubTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPagar;
        protected System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlMozo;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label lblCasa;
        private System.Windows.Forms.Label lblMzana;
        private System.Windows.Forms.TextBox txtCasa;
        private System.Windows.Forms.TextBox txtManz;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblMozo;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtCadete;
        private System.Windows.Forms.Panel pnlProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblCantidadProducto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.Label lblCodigos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCodigos;
        private System.Windows.Forms.NumericUpDown nudCantidad;
    }
}