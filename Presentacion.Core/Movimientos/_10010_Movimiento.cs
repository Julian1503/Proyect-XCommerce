using Presentacion.Core.VentasSalon;
using XCommerce.Servicio.Core.Movimiento.DTOs;

namespace Presentacion.Core.Movimientos
{
    using System;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Movimiento;

    public partial class _10010_Movimiento : FormularioBase.FormularioBase
    {
        private readonly IMovimientoServicio _movimientoServicio;
        public _10010_Movimiento()
        {
            InitializeComponent();
            _movimientoServicio = new MovimientoServicio();
        }

        private void _10010_Movimiento_Load(object sender, EventArgs e)
        {
            dgvGrilla.DataSource = _movimientoServicio.Obtener(string.Empty);
            Formatear();
        }

        private void ActualizarGrilla()
        {
            dgvGrilla.DataSource = _movimientoServicio.Obtener(dt.Value, dtpHasta.Value);
            Formatear();
        }
        private void DgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        private bool HayDatos()
        {
            return dgvGrilla.RowCount > 0;
        }

        private void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatos())
            {
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadSeleccionada = null;
            }
        }

        public object EntidadSeleccionada { get; set; }

        private void Formatear()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["TipoMovimientoStr"].Visible = true;
            dgvGrilla.Columns["TipoMovimientoStr"].Width = 150;
            dgvGrilla.Columns["TipoMovimientoStr"].HeaderText = @"Tipo Movimiento";
            dgvGrilla.Columns["TipoMovimientoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Fecha"].Visible = true;
            dgvGrilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Fecha"].HeaderText = @"Fecha";
            dgvGrilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Monto"].Visible = true;
            dgvGrilla.Columns["Monto"].Width = 100;
            dgvGrilla.Columns["Monto"].HeaderText = @"Monto";
            dgvGrilla.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (dt.Value <= dtpHasta.Value)
            {
                if (!_movimientoServicio.HayMovimientos(dt.Value, dtpHasta.Value)) MessageBox.Show("No hay movimiento entre estas fechas","Atencion");
                    ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("La Fecha 'Desde' debe ser menor a 'Hasta'","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("No hay comprobantes que detallar!", "Cuidado");
                return;
            }
            var fDet = new _10013_DetalleComprobante(((MovimientoDto)EntidadSeleccionada).ComprobanteId);
            fDet.ShowDialog();
        }
    }
}
