namespace Presentacion.FormularioBase
{
    using System;
    using System.Windows.Forms;
    using Helpers;
    using Presentacion.Core.Notificacion;

    public partial class FormularioAbm : FormularioBase
    {
        // Declaracion de Variables / Atributos
        protected TipoOp TipoOperacion;
        protected long? EntidadId;

        public bool RealizoAlgunaOperacion { get; set; }

        //Constructor Principal
        public FormularioAbm()
        {
            InitializeComponent();
            toolStrip1.BackColor = Constantes.Color.ColorMenu;
           
        }


        // Constructor Sobrecargado
        public FormularioAbm(TipoOp tipoOperacion, long? entidadId)
            : this() // => Constructor Principal
        {
            TipoOperacion = tipoOperacion;
            EntidadId = entidadId;

            RealizoAlgunaOperacion = false;
            AsignarImagenBotones();
        }

        private void AsignarImagenBotones()
        {
            if (TipoOperacion == TipoOp.Eliminar)
            {
                btnEjecutar.Text = @"Eliminar";
                btnEjecutar.Image = Constantes.ImagenesSistema.Eliminar;
            }
            else
            {
                btnEjecutar.Text = @"Guardar";
                btnEjecutar.Image = Constantes.ImagenesSistema.Guardar;
            }

            btnLimpiar.Image = Constantes.ImagenesSistema.Actualizar;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
        }

        public virtual void FormularioABM_Load(object sender, EventArgs e)
        {
            if (TipoOperacion == TipoOp.Eliminar
                || TipoOperacion == TipoOp.Modificar)
                CargarDatos(EntidadId);
        }

        public virtual void BtnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public virtual void btnEjecutar_Click(object sender, System.EventArgs e)
        {
            EjecutarComando();
        }

        public virtual void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta seguro de Limpiar los Datos", @"Atención", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(this);
            }
        }
        
        public virtual void EjecutarComando()
        {
            switch (TipoOperacion)
            {
                case TipoOp.Nuevo:
                    if (EjecutarComandoNuevo())
                    {
                        NotificacionCorrecta.MensajeSatisfactorio("Datos guardados");
                        Limpiar(this);
                        RealizoAlgunaOperacion = true;
                    }
                    break;
                case TipoOp.Eliminar:
                    if (EjecutarComandoEliminar())
                    {
                        NotificacionCorrecta.MensajeSatisfactorio("Datos eliminados");
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
                case TipoOp.Modificar:
                    if (EjecutarComandoModificar())
                    {
                        NotificacionCorrecta.MensajeSatisfactorio("Datos modificados");
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
            }
        }

        public virtual bool EjecutarComandoModificar()
        {
            return false;
        }

        public virtual bool EjecutarComandoEliminar()
        {
            return false;
        }

        public virtual bool EjecutarComandoNuevo()
        {
            return false;
        }
        
        public virtual void CargarDatos(long? entidadId)
        {

        }

        public virtual void Inicializador(long? entidadId)
        {

        }

        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            MovilidadSinBorde.Movilidad(this);    
        }
    }
}
