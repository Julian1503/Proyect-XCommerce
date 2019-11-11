namespace Presentacion.Core.Cliente
{
    using System.Drawing;
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using static Helpers.ImagenDb;
    using Localidad;
    using Provincia;
    using XCommerce.Servicio.Core.Cliente;
    using XCommerce.Servicio.Core.Cliente.DTOs;
    using XCommerce.Servicio.Core.Localidad;
    using XCommerce.Servicio.Core.Localidad.DTOs;
    using XCommerce.Servicio.Core.Provincia;
    using XCommerce.Servicio.Core.CuentaCorriente;
    using XCommerce.Servicio.Core.Provincia.DTOs;

    public partial class _00004_ABM_Cliente : FormularioAbm
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ICuentaCorrienteServicio _cuentaCorrienteServicio;
        private readonly ILocalidadServicio _localidadServicio;

        public _00004_ABM_Cliente(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();
            _cuentaCorrienteServicio = new CuentaCorrienteServicio(); 
            Validaciones();
            if (tipoOperacion == TipoOp.Eliminar || tipoOperacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtDni, "DNI");
            AgregarControlesObligatorios(txtCuil, "CUIL");
            AgregarControlesObligatorios(txtEmail, "E-Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");

            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtApellido.KeyPress += Validacion.NoSimbolos;
            txtApellido.KeyPress += Validacion.NoNumeros;
            txtNumero.KeyPress += Validacion.NoLetras;
            txtNombre.KeyPress += Validacion.NoSimbolos;
            txtNombre.KeyPress += Validacion.NoNumeros;
            txtNumero.KeyPress += Validacion.NoSimbolos;
            txtNumero.KeyPress += Validacion.NoLetras;

            txtDni.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoLetras;

            txtCuil.KeyPress += Validacion.NoSimbolos;
            txtCuil.KeyPress += Validacion.NoLetras;

            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;
            txtDepartamento.KeyPress += Validacion.NoNumeros;
            txtDepartamento.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoLetras;
            txtCasa.KeyPress += Validacion.NoSimbolos;
            txtLote.KeyPress += Validacion.NoSimbolos;
            txtManzana.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoLetras;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                var provincia = (ProvinciaDto)cmbProvincia.Items[0];

                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(provincia.Id, string.Empty), "Descripcion", "Id");
            }

            // Asignando un Evento
          

            imgFotoCliente.Image = Constantes.ImagenesSistema.PerfilVacio;

            txtApellido.Focus();
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

            var cliente = _clienteServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;
            txtDni.Text = cliente.Dni;
            txtTelefono.Text = cliente.Telefono;
            txtCelular.Text = cliente.Celular;
            txtEmail.Text = cliente.Email;
            txtCuil.Text = cliente.Cuil;
            dtpFechaNacimiento.Value = cliente.FechaNacimiento;
            imgFotoCliente.Image = Convertir_Bytes_Imagen(cliente.Foto);
            cbPermitirCtaCte.Checked = cliente.PermiteCtaCte;
            nudSobregiro.Value = cliente.Sobregiro;
            // Datos Direccion
            txtCalle.Text = cliente.Calle;
            txtNumero.Text = cliente.Numero.ToString();
            txtPiso.Text = cliente.Piso;
            txtDepartamento.Text = cliente.Dpto;
            txtCasa.Text = cliente.Casa;
            txtLote.Text = cliente.Lote;
            txtManzana.Text = cliente.Mza;
            txtBarrio.Text = cliente.Barrio;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            cmbProvincia.SelectedItem = cliente.ProvinciaId;

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(cliente.ProvinciaId, string.Empty), "Descripcion", "Id");
            }
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            CamposVacios();

            var nuevoCliente = new ClienteDto
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Celular = txtCelular.Text,
                Cuil = txtCuil.Text,
                Dni = txtDni.Text,
                Dpto = txtDepartamento.Text,
                Email = txtEmail.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Lote = txtLote.Text,
                Mza = txtManzana.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                Foto = Convertir_Imagen_Bytes(imgFotoCliente.Image),
                EstaEliminado = false,
                Sobregiro = nudSobregiro.Value
            };

            _clienteServicio.Insertar(nuevoCliente);

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
            CamposVacios();

            var clienteParaModificar = new ClienteDto
            {
                Id = EntidadId.Value,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Barrio = txtBarrio.Text,
                Calle = txtCalle.Text,
                Casa = txtCasa.Text,
                Celular = txtCelular.Text,
                Cuil = txtCuil.Text,
                Dni = txtDni.Text,
                Dpto = txtDepartamento.Text,
                Email = txtEmail.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Lote = txtLote.Text,
                Mza = txtManzana.Text,
                Numero = int.TryParse(txtNumero.Text, out var numero) ? numero : 0,
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                Foto = Convertir_Imagen_Bytes(imgFotoCliente.Image),
                EstaEliminado = false,
                Sobregiro = nudSobregiro.Value
            };
            return RevisandoSiPuedeModificar(clienteParaModificar);
        }

        private bool RevisandoSiPuedeModificar(ClienteDto clienteParaModificar)
        {
            var cuenta = _cuentaCorrienteServicio.TieneCuenta(EntidadId.Value);

            if (cuenta)
            {
                if (_cuentaCorrienteServicio.ObtenerCorrientePorClienteId(EntidadId.Value).Limite == nudSobregiro.Value)
                {

                    _clienteServicio.Modificar(clienteParaModificar);

                    return true;
                }
                if (_cuentaCorrienteServicio.ObtenerCorrientePorClienteId(EntidadId.Value).Saldo == 0)
                {
                    _clienteServicio.Modificar(clienteParaModificar);

                    return true;
                }
                else
                {
                    MessageBox.Show("El cliente debe dinero, no se puede modificar");
                    return false;
                }
            }
            else
            {
                _clienteServicio.Modificar(clienteParaModificar);
                return true;
            }
        }

        private void CamposVacios()
        {
            if (string.IsNullOrEmpty(txtBarrio.Text))
            {
                txtBarrio.Text = "-";
            }
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                txtBarrio.Text = "-";
            }
            if (string.IsNullOrEmpty(txtCelular.Text))
            {
                txtCelular.Text = "S/N";
            }
            if (string.IsNullOrEmpty(txtCasa.Text))
            {
                txtCasa.Text = "-";
            }
            if (string.IsNullOrEmpty(txtLote.Text))
            {
                txtLote.Text = "-";
            }
            if (string.IsNullOrEmpty(txtManzana.Text))
            {
                txtManzana.Text = "-";
            }
            if (string.IsNullOrEmpty(txtDepartamento.Text))
            {
                txtDepartamento.Text = "-";
            }
            if (string.IsNullOrEmpty(txtPiso.Text))
            {
                txtPiso.Text = "-";
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtTelefono.Text = "S/N";
            }
        }


        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            if (_cuentaCorrienteServicio.ObtenerCorrientePorClienteId(EntidadId.Value).Saldo == 0)
            {
            _clienteServicio.Eliminar(EntidadId.Value);
                return true;
            }
            else
            {
                MessageBox.Show("El cliente debe dinero, no se puede modificar");
                return false;
            }

        }
        
        private void CmbProvincia_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private void BtnAgregarImagen_Click(object sender, System.EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgFotoCliente.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgFotoCliente.Image = Constantes.ImagenesSistema.PerfilVacio;
                }
            }
            else
            {
                imgFotoCliente.Image = Constantes.ImagenesSistema.PerfilVacio;
            }
        }

        private void BtnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincia_ABM(TipoOp.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (!fNuevaProvincia.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void BtnLocalidad_Click(object sender, System.EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOp.Nuevo);
            fNuevaLocalidad.ShowDialog();

            if (!fNuevaLocalidad.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void cbPermitirCtaCte_CheckedChanged(object sender, System.EventArgs e)
        {
            nudSobregiro.Enabled = cbPermitirCtaCte.Checked ? true : false;
            nudSobregiro.Value = !cbPermitirCtaCte.Checked ? 0 : nudSobregiro.Value;
            lblSobregiro.Enabled = cbPermitirCtaCte.Checked ? true : false;
            nudSobregiro.Increment = cbPermitirCtaCte.Checked ? 1 : 0;
        }
    }
}
