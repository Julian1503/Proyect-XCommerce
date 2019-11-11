namespace Presentacion.Core.Reserva
{
    using System;
    using System.Windows.Forms;
    using Cliente;
    using FormularioBase;
    using Helpers;
    using Mesa;
    using MotivoReserva;
    using XCommerce.AccesoDatos;
    using XCommerce.Servicio.Core.Cliente;
    using XCommerce.Servicio.Core.Entidad;
    using XCommerce.Servicio.Core.Mesa;
    using XCommerce.Servicio.Core.Mesa.DTOs;
    using XCommerce.Servicio.Core.MotivoReserva;
    using XCommerce.Servicio.Core.MotivoReserva.DTOs;
    using XCommerce.Servicio.Core.Reserva;
    using XCommerce.Servicio.Core.Reserva.DTOs;
    using XCommerce.Servicio.Seguridad.Usuario;

    public partial class _00030_ABM_Reserva : FormularioAbm
    {
        private readonly IReservaServicio _reservaServicio;
        private readonly IMotivoReservaServicio _motivoReservaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly IMesaServicio _mesaServicio;
        private long _clienteId;
        public _00030_ABM_Reserva(TipoOp tipoOperacion, long? entidadId = null)
           : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _reservaServicio = new ReservaServicio();
            _motivoReservaServicio = new MotivoReservaServicio();
            _mesaServicio = new MesaServicio();
            _usuarioServicio  = new UsuarioServicio();
            _clienteServicio = new ClienteServicio();
            if (tipoOperacion == TipoOp.Eliminar || tipoOperacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);
            
            AgregarControlesObligatorios(nudSenia.Value, "Senia");

            AgregarControlesObligatorios(cmbMesa, "Mesa");

            AgregarControlesObligatorios(cmbEstadoReserva, "Estado de Reserva");

            AgregarControlesObligatorios(cmbMotivoReserva, "Motivo de Reserva");

            AgregarControlesObligatorios(txtCliente, "Cliente");

            AgregarControlesObligatorios(txtUsuario, "Usuario");



            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbMotivoReserva, _motivoReservaServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbMesa, _mesaServicio.ObtenerSinReservas(), "Descripcion", "Id");
            cmbEstadoReserva.SelectedIndex = 0;
            _clienteId = 0;
            txtUsuario.Text = Entidad.NombreUsuario;

            if (cmbMotivoReserva.Items.Count > 0)
            {
                var motivoReserva = (MotivoReservaDto) cmbMotivoReserva.Items[0];

            }

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

            var reserva = _reservaServicio.ObtenerPorId(entidadId.Value);
       
            cmbEstadoReserva.SelectedIndex = reserva.EstadoReserva == EstadoReserva.Confirmada? 0 : reserva.EstadoReserva == EstadoReserva.NoConfirmada ? 1 : 2;
            nudSenia.Value = reserva.Senia;
            txtUsuario.Text = Entidad.NombreUsuario;
            _clienteId = reserva.ClienteId;
            CargarComboBox(cmbMotivoReserva, _motivoReservaServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbMesa, _mesaServicio.ObtenerSinReservas(), "Descripcion", "Id");
            cmbMotivoReserva.SelectedItem = reserva.MotivoReservaId;
            cmbMesa.SelectedItem = reserva.MesaId;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaReserva = new ReservaDto
            {
                EstadoReserva = cmbEstadoReserva.SelectedIndex == 0 ? EstadoReserva.Confirmada : cmbEstadoReserva.SelectedIndex == 1 ? EstadoReserva.NoConfirmada: EstadoReserva.Cancelada,
                Senia = nudSenia.Value,
                EstaEliminado = false,
                Fecha = DateTime.Now,
                MotivoReservaId = ((MotivoReservaDto)cmbMotivoReserva.SelectedItem).Id,
                UsuarioId = Entidad.UsuarioId,
                ClienteId = _clienteId,
                MesaId = ((MesaDto)cmbMesa.SelectedItem).Id
            };
            _reservaServicio.Agregar(nuevaReserva);
            
            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var reservaParaModificar = new ReservaDto()
            {
                Id = EntidadId.Value,
                EstadoReserva = cmbEstadoReserva.SelectedIndex == 0 ? EstadoReserva.Confirmada : cmbEstadoReserva.SelectedIndex == 1 ? EstadoReserva.NoConfirmada : EstadoReserva.Cancelada,
                Senia = nudSenia.Value,
                Fecha = DateTime.Now,
                MotivoReservaId = ((MotivoReservaDto)cmbMotivoReserva.SelectedItem).Id,
                UsuarioId = Entidad.UsuarioId,
                ClienteId = _clienteId,
                MesaId = ((MesaDto)cmbMesa.SelectedItem).Id

            };

            _reservaServicio.Modificar(reservaParaModificar);

            return true;
        }

           private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            var fNuevaReserva = new _00034_ABM_MotivoReserva(TipoOp.Nuevo);
            fNuevaReserva.ShowDialog();

            if (!fNuevaReserva.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbMotivoReserva, _motivoReservaServicio.Obtener(string.Empty), "Descripcion", "Id");

           
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _reservaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        

        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            var fMesa = new _00036_ABM_Mesa(TipoOp.Nuevo);
            fMesa.ShowDialog();
            if (!fMesa.RealizoAlgunaOperacion) return;
            CargarComboBox(cmbMesa, _mesaServicio.ObtenerSinReservas(), "Descripcion", "Id");

        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var fBuscar = new _10001_BusquedaCliente();
                fBuscar.ShowDialog();
                if (fBuscar.RealizoOperacion)
                {
                    var cliente = _clienteServicio.ObtenerPorId(fBuscar.ClienteId);
                    txtCliente.Text = $"{cliente.ApyNom}  DNI: {cliente.Dni}" ;
                    _clienteId = fBuscar.ClienteId;
                }
            }
        }
    }
}
