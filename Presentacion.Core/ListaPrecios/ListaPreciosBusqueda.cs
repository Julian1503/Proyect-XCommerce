using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;

namespace Presentacion.Core.ListaPrecios
{
    public partial class ListaPreciosBusqueda : FormularioBase.FormularioBusqueda
    {
        public string ListaNombre;
        public long ListaId;
        private readonly IListaPreciosServicio _listaPreciosServicio;
        public ListaPreciosBusqueda() : this(new ListaPreciosServicio())
        {
            InitializeComponent();
        }
        public ListaPreciosBusqueda(IListaPreciosServicio listaPreciosServicio)
        {
            _listaPreciosServicio = listaPreciosServicio;
        }
        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _listaPreciosServicio.Obtener(cadena);
        }

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Razon Social";
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Rentabilidad"].Visible = true;
            dgvGrilla.Columns["Rentabilidad"].HeaderText = @"Rentabilidad";
            dgvGrilla.Columns["Rentabilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Rentabilidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada != null)
            {
                RealizoOperacion = true;
                ListaNombre = ((ListaPreciosDto)EntidadSeleccionada).Descripcion;
                ListaId = ((ListaPreciosDto)EntidadSeleccionada).Id;
                this.Close();
            }
        }
    }
}
