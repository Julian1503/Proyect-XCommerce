using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Constantes;
using XCommerce.Servicio.Core.Proveedor;
using XCommerce.Servicio.Core.Proveedor.DTOs;

namespace Presentacion.Core.Proveedor
{
    public partial class _00001_SeleccionProveedor :FormularioBase.FormularioBusqueda
    {
        private readonly IProveedorServicio _proveedorServicio;
        public long ProveedorId;
        public string Nombre;
        public _00001_SeleccionProveedor() : this(new ProveedorServicio())
        {
            InitializeComponent();
        }

        public _00001_SeleccionProveedor(IProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _proveedorServicio.ObtenerSinEliminados(cadena);
        }

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);
            dgvGrilla.Columns["RazonSocial"].Visible = true;
            dgvGrilla.Columns["RazonSocial"].HeaderText = @"Razon Social";
            dgvGrilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["RazonSocial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Telefono"].Visible = true;
            dgvGrilla.Columns["Telefono"].HeaderText = @"Telefono";
            dgvGrilla.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Email"].Visible = true;
            dgvGrilla.Columns["Email"].HeaderText = @"Email";
            dgvGrilla.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Email"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Contacto"].Visible = true;
            dgvGrilla.Columns["Contacto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Contacto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Contacto"].HeaderText = @"Contacto";
        }

        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada != null)
            {
                ProveedorId = ((ProveedorDto)EntidadSeleccionada).Id;
                Nombre = ((ProveedorDto)EntidadSeleccionada).RazonSocial;
                RealizoOperacion = true;
                this.Close();
            }
        }
    }
}
