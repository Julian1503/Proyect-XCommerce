using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.ComprobanteCompra;

namespace Presentacion.Core.Proveedor
{
    public partial class ComprasRealizadas : FormularioBusqueda
    {
        private readonly IComprobanteCompraServicio _comprobanteCompraServicio;
        public ComprasRealizadas() : this(new ComprobanteCompraServicio())
        {
            InitializeComponent();
            this.Text = "Comprobantes de compra";
            this.btnSeleccionar.Text = "Revizar comprobante";
            btnSeleccionar.Text = "Compra proveedor";
            btnSeleccionar.Click += Boton_Click;
            //var boton = new ToolStripButton
            //{
            //    Name = "btnComprar",
            //    Text = "Comprar proveedor"
            //};
            //boton.Click += Boton_Click;
            //AgregarBotones(boton);
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            var fCompra = new _00010_CompraProveedor();
            fCompra.ShowDialog();
            if (fCompra.RealizoOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        public ComprasRealizadas(IComprobanteCompraServicio comprobanteCompraServicio) 
        {
            _comprobanteCompraServicio = comprobanteCompraServicio;
        }

        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _comprobanteCompraServicio.ObtenerComprobantesCompra(string.Empty);
        }
        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["NumeroComprobante"].Visible = true;
            dgvGrilla.Columns["NumeroComprobante"].Width = 75;
            dgvGrilla.Columns["NumeroComprobante"].HeaderText = @"Numero de comprobante";

            dgvGrilla.Columns["ProveedorRazonSocial"].Visible = true;
            dgvGrilla.Columns["ProveedorRazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ProveedorRazonSocial"].HeaderText = @"Proveedor";

            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Total"].Visible = true;
            dgvGrilla.Columns["Total"].Width = 100;
          
        }

    }
}
