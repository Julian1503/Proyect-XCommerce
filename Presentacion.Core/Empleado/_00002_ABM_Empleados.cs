namespace Presentacion.Core.Empleado
{
    using System.Drawing;
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using static Helpers.ImagenDb;
    using Localidad;
    using Provincia;
    using XCommerce.Servicio.Core.Empleado;
    using XCommerce.Servicio.Core.Empleado.DTOs;
    using XCommerce.Servicio.Core.Localidad;
    using XCommerce.Servicio.Core.Localidad.DTOs;
    using XCommerce.Servicio.Core.Provincia;
    using XCommerce.Servicio.Core.Provincia.DTOs;
    using XCommerce.Servicio.Core.Categoria;
    using XCommerce.Servicio.Core.Categoria.DTOs;
    using Presentacion.Core.Categoria;
    using System;
    using System.Collections.Generic;

    public sealed partial class _00002_ABM_Empleados : FormularioAbm
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ICategoriaServicio _categoriaServicio;
        private readonly ILocalidadServicio _localidadServicio;

        public _00002_ABM_Empleados(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _categoriaServicio = new CategoriaServicio();
            _empleadoServicio = new EmpleadoServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();

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

            AgregarControlesObligatorios(nudLegajo, "Legajo");
            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtDni, "DNI");
            AgregarControlesObligatorios(txtCuil, "CUIL");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");
            AgregarControlesObligatorios(txtEmail, "E-Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");

            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtApellido.KeyPress += Validacion.NoSimbolos;
            txtApellido.KeyPress += Validacion.NoNumeros;

            txtNombre.KeyPress += Validacion.NoSimbolos;
            txtNombre.KeyPress += Validacion.NoNumeros;

            txtDni.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoLetras;

            txtCuil.KeyPress += Validacion.NoSimbolos;
            txtCuil.KeyPress += Validacion.NoLetras;
            txtDepartamento.KeyPress += Validacion.NoNumeros;
            txtDepartamento.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoSimbolos;
            txtPiso.KeyPress += Validacion.NoLetras;
            txtCasa.KeyPress += Validacion.NoSimbolos;
            txtLote.KeyPress += Validacion.NoSimbolos;
            txtManzana.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;
            txtNumero.KeyPress += Validacion.NoSimbolos;
            txtNumero.KeyPress += Validacion.NoLetras;
            txtCelular.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoLetras;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;
            IEnumerable<CategoriaDto> a = _categoriaServicio.Obtener(string.Empty);
            IEnumerable<ProvinciaDto> b = _provinciaServicio.Obtener(string.Empty);
                CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

                CargarComboBox(cmbCategoria, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");
            

            if (cmbProvincia.Items.Count > 0)
            {
                var provincia = (ProvinciaDto)cmbProvincia.Items[0];

                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(provincia.Id, string.Empty), "Descripcion", "Id");
            }

            nudLegajo.Minimum = 1;
            nudLegajo.Maximum = 99999999;
            nudLegajo.Value = _empleadoServicio.ObtenerSiguienteLegajo();
       
            // Asignando un Evento
           

            imgFotoEmpleado.Image = Constantes.ImagenesSistema.PerfilVacio;

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

            var empleado = _empleadoServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            nudLegajo.Minimum = 1;
            nudLegajo.Maximum = 9999999999;
            nudLegajo.Value = empleado.Legajo;

            txtApellido.Text = empleado.Apellido;
            txtNombre.Text = empleado.Nombre;
            txtDni.Text = empleado.Dni;
            txtTelefono.Text = empleado.Telefono;
            txtCelular.Text = empleado.Celular;
            txtEmail.Text = empleado.Email;
            txtCuil.Text = empleado.Cuil;
            dtpFechaNacimiento.Value = empleado.FechaNacimiento;
            imgFotoEmpleado.Image = Convertir_Bytes_Imagen(empleado.Foto);

            // Datos Direccion
            txtCalle.Text = empleado.Calle;
            txtNumero.Text = empleado.Numero.ToString();
            txtPiso.Text = empleado.Piso;
            txtDepartamento.Text = empleado.Dpto;
            txtCasa.Text = empleado.Casa;
            txtLote.Text = empleado.Lote;
            txtManzana.Text = empleado.Mza;
            txtBarrio.Text = empleado.Barrio;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbCategoria, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbCategoria.SelectedValue = empleado.CategoriaId;
            cmbProvincia.SelectedValue = empleado.ProvinciaId;
            
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(empleado.ProvinciaId, string.Empty), "Descripcion", "Id");
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
            var nuevoEmpleado = new EmpleadoDto
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Legajo = (int)nudLegajo.Value,
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
                CategoriaId = ((CategoriaDto)cmbCategoria.SelectedItem).Id,
                Foto = Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
                EstaEliminado = false,
                FechaIngreso = dtpFechaIngreso.Value
            };

            _empleadoServicio.Insertar(nuevoEmpleado);

            return true;
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

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            CamposVacios();

            var empleadoParaModificar = new EmpleadoDto
            {
                Id = EntidadId.Value,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Legajo = (int)nudLegajo.Value,
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
                Numero = int.Parse(txtNumero.Text),
                Piso = txtPiso.Text,
                Telefono = txtTelefono.Text,
                CategoriaId = ((CategoriaDto)cmbCategoria.SelectedItem).Id,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                Foto = Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
                EstaEliminado = false,
                FechaIngreso = dtpFechaIngreso.Value
            };

            _empleadoServicio.Modificar(empleadoParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _empleadoServicio.Eliminar(EntidadId.Value);

            return true;
        }

        public override void EjecutarComando()
        {
            base.EjecutarComando();

            if (TipoOperacion == TipoOp.Nuevo)
                nudLegajo.Value = _empleadoServicio.ObtenerSiguienteLegajo();
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
                    imgFotoEmpleado.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgFotoEmpleado.Image = Constantes.ImagenesSistema.PerfilVacio;
                }
            }
            else
            {
                imgFotoEmpleado.Image = Presentacion.Constantes.ImagenesSistema.PerfilVacio;
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
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto) cmbProvincia.SelectedItem).Id, string.Empty),
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

        private void _00002_ABM_Empleados_Load(object sender, System.EventArgs e)
        {

        }

        private void btnCategoria_Click(object sender, System.EventArgs e)
        {
            var fCategoriaAbm = new _00017_Categoria_ABM(TipoOp.Nuevo);
            fCategoriaAbm.ShowDialog();

            if (!fCategoriaAbm.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbCategoria, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");

        }
    }
}
