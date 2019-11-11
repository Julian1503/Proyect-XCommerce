namespace Presentacion.Core.Venta
{
    using Presentacion.Core.Mesa;
    using Presentacion.Core.Salon;
    using Presentacion.Helpers;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Ventas.Controladores;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.Mesa;
    using XCommerce.Servicio.Core.Salon;

    public partial class _00038_VentaSalon : FormularioBase.FormularioBase
    {
        private readonly ISalonServicio _salonServicio;
        private readonly IMesaServicio _mesaServicio;
        public _00038_VentaSalon() :this(new SalonServicio(), new MesaServicio())
        {
            InitializeComponent();
            CrearControles();
        }
        public _00038_VentaSalon(ISalonServicio salonServicio, IMesaServicio mesaServicio)
        {
            _salonServicio = salonServicio;
            _mesaServicio = mesaServicio;
        }

        private void CrearControles()
        {

            var contenedorSalones = new TabControl();
            var contadorTabIndex=0;
            var salones = _salonServicio.Obtener(string.Empty);
            foreach (var i in salones.Where(x=>!x.EstaEliminado))
            {
                var flowPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Name=$"flow{i.Id}",
                    Dock = DockStyle.Fill,
                    Location = new Point(3,3),
                    Size = new Size(848,351),
                    TabIndex = 0
                };
                foreach (var mesa in _mesaServicio.ObtenerPorSalon(i.Id,string.Empty)
                    .Where(x=>!x.EstaEliminado))
                {
                    if (mesa.TipoMesa == TipoMesa.Cuadrada)
                    {   
                        var control = new CtrolMesa
                        {
                            MesaId=mesa.Id,
                            Name = $"Mesa {mesa.Id}",
                            Numero = mesa.Numero,
                            PrecioConsumido = 0m,
                            EstadoMesa = mesa.EstadoMesa
                        };

                        flowPanel.Controls.Add(control);
                    }
                    else
                    {
                        var control = new CtrolMesaRedonda
                        {
                            MesaId=mesa.Id,
                            Name = $"Mesa {mesa.Id}",
                            Numero = mesa.Numero,
                            PrecioConsumido = 0m,
                            EstadoMesa = mesa.EstadoMesa
                        };

                        flowPanel.Controls.Add(control);
                    }
                }
                var salonPage = new TabPage
                {
                    Location = new Point(4, 22),
                    Name = $"Pagina{i.Id}",
                    Padding = new Padding(3),
                    Size = new Size(792, 370),
                    TabIndex = contadorTabIndex,
                    Text = i.Descripcion,
                    UseVisualStyleBackColor = true
                }; 
                salonPage.Controls.Add(flowPanel);
                contenedorSalones.Controls.Add(salonPage);
                contadorTabIndex++;
            }

            contenedorSalones.Dock = DockStyle.Fill;
            contenedorSalones.Location = new Point(0, 54);
            contenedorSalones.Name = "contenedorSalones";
            contenedorSalones.SelectedIndex = 0;
            contenedorSalones.Size = new Size(800, 396);
            contenedorSalones.TabIndex = 9;
            contenedorSalones.Padding = new Point(20,15);
            contenedorSalones.ResumeLayout(false);

            this.Controls.Add(contenedorSalones);
            this.Controls.SetChildIndex(contenedorSalones,0);
            contenedorSalones.ResumeLayout(false);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaMesa_Click(object sender, EventArgs e)
        {
            var fMesa = new _00036_ABM_Mesa(TipoOp.Nuevo);
            fMesa.ShowDialog();
            if (fMesa.RealizoAlgunaOperacion)
            {
                CrearControles();
            }
        }

        private void btnNuevoSalon_Click(object sender, EventArgs e)
        {
            var fSalon = new _00028_ABM_Salon(TipoOp.Nuevo);
            fSalon.ShowDialog();
            if (fSalon.RealizoAlgunaOperacion)
            {
                CrearControles();
            }
        }
    }
}
