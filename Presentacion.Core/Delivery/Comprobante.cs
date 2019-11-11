using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Base;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Delivery;
using XCommerce.Servicio.Core.Delivery.DTOs;
using XCommerce.Servicio.Core.Empresa;
using XCommerce.Servicio.Core.Empresa.DTOs;
using XCommerce.Servicio.Core.Entidad;

namespace Presentacion.Core.Delivery
{
    public partial class Comprobante : Form
    {
        private Bitmap memoryImage;
        protected ClienteDto cliente;
        protected ComprobanteBase comprobante;
        protected EmpresaDto empresa;

        public Comprobante()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            lblRazonSocialEmpresa.Text = $"Razon social: {empresa.RazonSocial}";
            lblCondicionIv.Text = $"Condicion Iva:{empresa.CondicionIvaIdDescripcion}";
            lblCuit.Text = $"CUIT: {empresa.Cuit}";
            lblCuitCliente.Text = $"CUIT: {cliente.Cuil}";
            lblDomicilio.Text = $"Domicilio: {cliente.DireccionCompleta}";
            lblDomicilioEmpresa.Text = $"Domicilio Comercial: {empresa.DireccionCompleta}";
            lblNombreCliente.Text = $"Apellido y Nombre: {comprobante.ClienteNombreCompleto}";

            lblNumeroComprobante.Text = $"N°:{comprobante.NumeroComprobante.ToString("000000")}";
            lblFecha.Text = $"Fecha de emision: {comprobante.Fecha.ToShortDateString()}";
            lblTotalComprobante.Text = $"${comprobante.Total}";
            lblSubtotalComprobante.Text = $"${comprobante.SubTotal}";
            lblDescuentoComprobante.Text = $"%{comprobante.Descuento}";
            lblTipoComprobante.Text = comprobante.TipoComprobante == XCommerce.AccesoDatos.TipoComprobante.A ? $"A" : comprobante.TipoComprobante == XCommerce.AccesoDatos.TipoComprobante.B ? $"B" : comprobante.TipoComprobante == XCommerce.AccesoDatos.TipoComprobante.C ? $"C" : $"X";
            foreach (var item in comprobante.Items)
            {
                // 
                // lblCodigoProducto
                // 
                var lblCodigoProducto = new Label();
                lblCodigoProducto.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                lblCodigoProducto.Location = new Point(-1, -1);
                lblCodigoProducto.Name = $"lblCodigoProducto{item.ArticuloId}";
                lblCodigoProducto.Size = new Size(86, 28);
                lblCodigoProducto.TabIndex = 7;
                lblCodigoProducto.Text = item.CodigoProducto;
                lblCodigoProducto.TextAlign = ContentAlignment.MiddleCenter;
                // 
                // lblDescripcionProducto
                // 
                var lblDescripcionProducto = new Label();
                lblDescripcionProducto.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                lblDescripcionProducto.Location = new Point(87, -1);
                lblDescripcionProducto.Name = $"lblDescripcionProducto{item.ArticuloId}";
                lblDescripcionProducto.Size = new Size(215, 28);
                lblDescripcionProducto.TabIndex = 8;
                lblDescripcionProducto.Text = item.Descripcion;
                lblDescripcionProducto.TextAlign = ContentAlignment.MiddleCenter;
                // 
                // lblCantidadProducto
                // 
                var lblCantidadProducto = new Label();
                lblCantidadProducto.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                lblCantidadProducto.Location = new Point(306, -2);
                lblCantidadProducto.Name = $"lblCantidadProducto{item.ArticuloId}";
                lblCantidadProducto.Size = new Size(79, 28);
                lblCantidadProducto.TabIndex = 9;
                lblCantidadProducto.Text = item.Cantidad.ToString();
                lblCantidadProducto.TextAlign = ContentAlignment.MiddleCenter;
                // 
                // lblPrecioProducto
                // 
                var lblPrecioProducto = new Label();
                lblPrecioProducto.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                lblPrecioProducto.Location = new Point(389, -1);
                lblPrecioProducto.Name = $"lblPrecioProducto{item.ArticuloId}";
                lblPrecioProducto.Size = new Size(132, 28);
                lblPrecioProducto.TabIndex = 10;
                lblPrecioProducto.Text = item.PrecioUnitario.ToString();
                lblPrecioProducto.TextAlign = ContentAlignment.MiddleCenter;
                // 
                // lblSubtotalProducto
                // 
                var lblSubtotalProducto = new Label();
                lblSubtotalProducto.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                lblSubtotalProducto.Location = new Point(525, -1);
                lblSubtotalProducto.Name = $"lblSubtotalProducto{item.ArticuloId}";
                lblSubtotalProducto.Size = new Size(113, 28);
                lblSubtotalProducto.TabIndex = 11;
                lblSubtotalProducto.Text = item.SubTotal.ToString();
                lblSubtotalProducto.TextAlign = ContentAlignment.MiddleCenter;
                var pnlItemNuevo = new Panel();
                pnlItemNuevo.BorderStyle = BorderStyle.FixedSingle;
                pnlItemNuevo.Controls.Add(lblSubtotalProducto);
                pnlItemNuevo.Controls.Add(lblPrecioProducto);
                pnlItemNuevo.Controls.Add(lblCantidadProducto);
                pnlItemNuevo.Controls.Add(lblDescripcionProducto);
                pnlItemNuevo.Controls.Add(lblCodigoProducto);
                pnlItemNuevo.Dock = DockStyle.Top;
                pnlItemNuevo.Name = $"pnlItem{item.ArticuloId}";
                pnlItemNuevo.Size = new Size(638, 28);
                panel1.Controls.Add(pnlItemNuevo);
                
            }
           
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            this.Size = new Size(664, this.Height + e.Control.Height);   
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MovilidadSinBorde.Movilidad(this);
        }


        private void Comprobante_Click(object sender, EventArgs e)
        {
         
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            pnlCerrar.Visible = false;
            btnCerrar.Visible = false;
            CaptureScreen();
            pnlCerrar.Visible = true;
            btnCerrar.Visible = true;
        }
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height - pnlBtnImprimir.Size.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0 , s);
           printPreviewDialog1.Document = printDocument1;
           printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
