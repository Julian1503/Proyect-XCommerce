namespace Presentacion.Core.Mesa
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using Salon;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.Mesa;
    using XCommerce.Servicio.Core.Mesa.DTOs;
    using XCommerce.Servicio.Core.Salon;
    using XCommerce.Servicio.Core.Salon.DTOs;
    using XCommerce.AccesoDatos;
    public partial class _00036_ABM_Mesa : FormularioAbm
    {
        private readonly ISalonServicio _salonServicio;
        private readonly IMesaServicio _mesaServicio;

        public _00036_ABM_Mesa(TipoOp operacion, long? entidadId = null)
            : base (operacion, entidadId)
        {
            InitializeComponent();

            _salonServicio = new SalonServicio();
            _mesaServicio = new MesaServicio();
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            if (operacion == TipoOp.Eliminar || operacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (operacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            AgregarControlesObligatorios(cmbSalon, "Salon");
            AgregarControlesObligatorios(cmbTipo, "Tipo");
            AgregarControlesObligatorios(nudNumero, "Numero");



            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbSalon, _salonServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbTipo.SelectedIndex = 0;

            // Asignando un Evento

            nudNumero.Value = _mesaServicio.ObtenerSiguienteNumero();
            txtDescripcion.Focus();

        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOp.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            CargarComboBox(cmbSalon, _salonServicio.Obtener(string.Empty), "Descripcion", "Id");

            


            var mesa = _mesaServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = mesa.Descripcion;
            cmbTipo.SelectedIndex = mesa.TipoMesa == TipoMesa.Cuadrada ? 0 : 1;
            nudNumero.Value = mesa.Numero;

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaMesa = new MesaDto
            {
                EstadoMesa =EstadoMesa.Cerrada,
                Descripcion = txtDescripcion.Text,
                SalonId = ((SalonDto)cmbSalon.SelectedItem).Id,
                Numero = (int) nudNumero.Value,
                TipoMesa =  cmbTipo.SelectedIndex ==0? TipoMesa.Cuadrada : TipoMesa.Redonda
            };

            _mesaServicio.Agregar(nuevaMesa);
            return true;
        }

        public override void EjecutarComando()
        {
            base.EjecutarComando();

            if (TipoOperacion == TipoOp.Nuevo)
                nudNumero.Value= _mesaServicio.ObtenerSiguienteNumero();
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var mesaParaModificar = new MesaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                SalonId = ((SalonDto)cmbSalon.SelectedItem).Id,
                TipoMesa = cmbTipo.SelectedIndex == 0 ? TipoMesa.Cuadrada : TipoMesa.Redonda,
                Numero = (int) nudNumero.Value
            };

            _mesaServicio.Modificar(mesaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _mesaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void btnNuevoSalon_Click(object sender, EventArgs e)
        {
            var fNuevoSalon = new _00028_ABM_Salon(TipoOp.Nuevo);
            fNuevoSalon.ShowDialog();

            if (fNuevoSalon.RealizoAlgunaOperacion)
            {
                CargarComboBox(cmbSalon, _salonServicio.Obtener(string.Empty), "Descripcion", "Id");
            }
        }
    }
}
