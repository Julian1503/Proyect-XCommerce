namespace Presentacion.Core.Salon
{
    using System;
    using System.Windows.Forms;
    using ListaPrecios;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.ListaPrecio;
    using XCommerce.Servicio.Core.ListaPrecio.DTOs;
    using XCommerce.Servicio.Core.Salon;
    using XCommerce.Servicio.Core.Salon.DTOs;

    public partial class _00028_ABM_Salon : FormularioAbm
    {
        private readonly ISalonServicio _salonServicio;
        private readonly IListaPreciosServicio _listaPreciosServicio;
        public _00028_ABM_Salon(TipoOp tipoOperacion, long? entidadId = null)
            : base (tipoOperacion, entidadId)
        {
            InitializeComponent();
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            _salonServicio = new SalonServicio();
            _listaPreciosServicio = new ListaPreciosServicio();
            if (tipoOperacion == TipoOp.Eliminar || tipoOperacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }

            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            if (tipoOperacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento
            CargarComboBox(cmbLista,_listaPreciosServicio.Obtener(string.Empty),"Descripcion","Id");
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

            var salon = _salonServicio.ObtenerPorId(entidadId.Value);
            CargarComboBox(cmbLista, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbLista.SelectedValue = salon.ListaPreciosId;
            // Datos Personales
            txtDescripcion.Text = salon.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoSalon = new SalonDto
            {
                Descripcion = txtDescripcion.Text,
                ListaPreciosId = ((ListaPreciosDto)cmbLista.SelectedItem).Id
            };

            _salonServicio.Agregar(nuevoSalon);

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

            var salonParaModificar = new SalonDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                ListaPreciosId = ((ListaPreciosDto)cmbLista.SelectedItem).Id
            };

            _salonServicio.Modificar(salonParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _salonServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            var fLista = new _00026_ABM_ListaPrecios(TipoOp.Nuevo);
            fLista.ShowDialog();
            if(fLista.RealizoAlgunaOperacion)
                CargarComboBox(cmbLista, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");

        }
    }
}
