using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Banco;
using XCommerce.Servicio.Core.Banco.DTOs;

namespace Presentacion.Core.Banco
{
    public partial class _00001_BuscarBancos : FormularioBase.FormularioBusqueda
    {
        private readonly IBancoServicio _bancoServicio;
        public long BancoId { get; private set; }
        public string NombreBanco { get; private set; }


        public _00001_BuscarBancos() : this(new BancoServicio())
        {
            InitializeComponent();
        }

        public _00001_BuscarBancos(BancoServicio bancoServicio)
        {
            _bancoServicio = bancoServicio;
        }

        protected override void ActualizarDatos(DataGridView grilla, string cadena)
        {
            grilla.DataSource = _bancoServicio.Obtener(cadena);
        }

        protected override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);
            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada == null)
            {
                MessageBox.Show("Seleccion una fila");
                return;
            }
            if (EntidadSeleccionada == null) MessageBox.Show("Seleccion una fila");
            BancoId = ((BancoDto)EntidadSeleccionada).Id;
            NombreBanco = ((BancoDto) EntidadSeleccionada).Descripcion;
            RealizoOperacion = true;

            this.Close();
        }
    }
}
