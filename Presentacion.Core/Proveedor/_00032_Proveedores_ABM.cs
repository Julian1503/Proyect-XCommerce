namespace Presentacion.Core.Proveedor
{
    using System;
    using System.Windows.Forms;
    using CondicionIva;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.CondicionIva;
    using XCommerce.Servicio.Core.CondicionIva.DTOs;
    using XCommerce.Servicio.Core.Proveedor;
    using XCommerce.Servicio.Core.Proveedor.DTOs;

    public partial class _00032_Proveedores_ABM : FormularioAbm
    {
        private readonly IProveedorServicio _proveedorServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00032_Proveedores_ABM(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            Validaciones();
            _proveedorServicio = new ProveedorServicio();
            _condicionIvaServicio=new CondicionIvaServicio();
            if (tipoOperacion == TipoOp.Eliminar || tipoOperacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtRazonSocial, "RazonSocial");
            AgregarControlesObligatorios(txtTelefono, "Telefono");
            AgregarControlesObligatorios(txtEmail, "Email");
            AgregarControlesObligatorios(txtContacto, "Contacto");
            AgregarControlesObligatorios(cmbCondicionIva, "Condicion IVA");

            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;
            txtContacto.KeyPress += Validacion.NoSimbolos;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento
            CargarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");



            txtContacto.Focus();
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

            var proveedor = _proveedorServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtContacto.Text = proveedor.Contacto;
            txtEmail.Text = proveedor.Email;
            txtRazonSocial.Text = proveedor.RazonSocial;
            txtTelefono.Text = proveedor.Telefono;
            CargarComboBox(cmbCondicionIva,_condicionIvaServicio.Obtener(string.Empty),"Descripcion","Id");
 


        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoProveedor = new ProveedorDto
            {
                Contacto = txtContacto.Text,
                RazonSocial = txtRazonSocial.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                CondicionIvaId = ((CondicionIvaDto)cmbCondicionIva.SelectedItem).Id
            };

            _proveedorServicio.Agregar(nuevoProveedor);

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

            var proveedorParaModificar = new ProveedorDto
            {
                Id = EntidadId.Value,
                Contacto = txtContacto.Text,
                Email = txtEmail.Text,
                RazonSocial = txtRazonSocial.Text,
                Telefono = txtTelefono.Text,
                CondicionIvaId = ((CondicionIvaDto)cmbCondicionIva.SelectedItem).Id
            };

            _proveedorServicio.Modificar(proveedorParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _proveedorServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void _00010_Proveedores_ABM_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarCondicionIva_Click(object sender, EventArgs e)
        {
            var fCondicion = new _00024_ABM_CondicionIva(TipoOp.Nuevo);
            fCondicion.ShowDialog();
            if (fCondicion.RealizoAlgunaOperacion)
            {
                CargarComboBox(cmbCondicionIva, _condicionIvaServicio.Obtener(string.Empty), "Descripcion", "Id");
            }
        }
    }
}
