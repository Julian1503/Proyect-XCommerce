using System;
using System.Drawing;
using System.Windows.Forms;
using XCommerce.AccesoDatos;

namespace Presentacion.Core.VentasSalon
{
    using Helpers;
    using Reserva;

    public partial class _10016_ReservarMesa : _00030_ABM_Reserva
    {
        public bool Confirmado;
        public decimal Monto;
        public _10016_ReservarMesa() : base(TipoOp.Nuevo)
        {
            InitializeComponent();
            Confirmado = false;
            this.Text = "Reservar Mesa";
        }

        public _10016_ReservarMesa(long mesaId) :this()
        {
            btnAgregarMesa.Enabled = false;
            cmbMesa.SelectedItem = mesaId;
            cmbMesa.Enabled = false;
            this.Size = new Size(405, 333);
            this.MaximumSize = Size;
            this.MinimumSize = Size;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public override bool EjecutarComandoNuevo()
        {
            return base.EjecutarComandoNuevo();
            if (cmbEstadoReserva.SelectedIndex == 0)
            {
                Confirmado = true;
            }
            this.Close();
        }
    }
}
