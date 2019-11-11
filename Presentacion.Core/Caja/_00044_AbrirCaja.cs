namespace Presentacion.Core.Caja
{
    using System;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.DetalleCaja;
    using XCommerce.Servicio.Core.Caja;
    using XCommerce.Servicio.Core.Caja.DTOs;
    using XCommerce.Servicio.Core.Entidad;

    public partial class _00044_AbrirCaja : FormularioBase.FormularioBase
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        public _00044_AbrirCaja()
        {
            InitializeComponent();
            btnAbrirCaja.Image = Constantes.ImagenesSistema.Caja;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
            menuAccesoRapido.BackColor = Constantes.Color.ColorMenu;
            _cajaServicio = new CajaServicio();
            _detalleCajaServicio= new DetalleCajaServicio();
            Inicializar();
        }

        private void Inicializar()
        {
            txtUsuario.Text = Entidad.NombreUsuario;
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            var caja = new CajaDto
            {
                
                MontoApertura = nudMonto.Value,
                UsuarioAperturaId = Entidad.UsuarioId,
                MontoCierre = 0,
                UsuarioCierreId = 0
                
            };
            Entidad.CajaId= _cajaServicio.Abrir(caja);
            Entidad.CajaAbierta = true;
            if(nudMonto.Value>0)
                _detalleCajaServicio.Generar(nudMonto.Value, TipoPago.Efectivo);
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
