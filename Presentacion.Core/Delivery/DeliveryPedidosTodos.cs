using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Delivery;

namespace Presentacion.Core.Delivery
{
    public partial class DeliveryPedidosTodos : FormularioBase.FormularioBusqueda
    {
        private readonly IDeliveryServicio _deliveryServicio;
        public DeliveryPedidosTodos() : this(new DeliveryServicio())
        {
            InitializeComponent();
            btnSeleccionar.Visible = false;
        }
        public DeliveryPedidosTodos(IDeliveryServicio deliveryServicio)
        {
            _deliveryServicio = deliveryServicio;
        }
        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            dgvGrilla.DataSource = _deliveryServicio.ObtenerTodos(string.Empty);
        }
        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);
            
            dgvGrilla.Columns["ClienteNombreCompleto"].Visible = true;
            dgvGrilla.Columns["ClienteNombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ClienteNombreCompleto"].HeaderText = @"Cliente";
            dgvGrilla.Columns["ClienteNombreCompleto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["CadeteNombreCompleto"].Visible = true;
            dgvGrilla.Columns["CadeteNombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["CadeteNombreCompleto"].HeaderText = @"Cadete";
            dgvGrilla.Columns["CadeteNombreCompleto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Direccion"].Visible = true;
            dgvGrilla.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Direccion"].HeaderText = @"Direccion";
            dgvGrilla.Columns["Direccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Fecha"].HeaderText = @"Fecha";
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Estado"].Visible = true;
            dgvGrilla.Columns["Estado"].Width = 90;
            dgvGrilla.Columns["Estado"].HeaderText = @"Estado";
            dgvGrilla.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach(DataGridViewRow i in dgvGrilla.Rows)
            {
                switch ((EstadoPedido)dgvGrilla.Rows[i.Index].Cells["Estado"].Value)
                {
                    case EstadoPedido.Pendiente:
                        dgvGrilla.Rows[i.Index].Cells["Estado"].Style.ForeColor = Color.FromArgb(255, 141, 0);
                        break;
                    case EstadoPedido.Entregado:
                        dgvGrilla.Rows[i.Index].Cells["Estado"].Style.ForeColor = Color.FromArgb(0, 190, 113);
                        break;
                    case EstadoPedido.Enviado:
                        dgvGrilla.Rows[i.Index].Cells["Estado"].Style.ForeColor = Color.FromArgb(0, 168, 231);
                        break;
                    case EstadoPedido.Cancelado:
                        dgvGrilla.Rows[i.Index].Cells["Estado"].Style.ForeColor = Color.FromArgb(188, 80, 78);
                        break;
                }
            }
            dgvGrilla.Columns["Total"].Visible = true;
            dgvGrilla.Columns["Total"].Width = 90;
            dgvGrilla.Columns["Total"].HeaderText = @"Total";
            dgvGrilla.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
    }
}
