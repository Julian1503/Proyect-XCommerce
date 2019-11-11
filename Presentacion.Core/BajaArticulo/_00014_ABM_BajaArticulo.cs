namespace Presentacion.Core.BajaArticulo
{
    using System;
    using System.Windows.Forms;
    using Articulo;
    using FormularioBase;
    using Helpers;
    using MotivoBaja;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.BajaArticulo;
    using XCommerce.Servicio.Core.BajaArticulo.DTOs;
    using XCommerce.Servicio.Core.MotivoBaja;
    using XCommerce.Servicio.Core.MotivoBaja.DTOs;

    public partial class _00014_ABM_BajaArticulo : FormularioAbm
    {
        private readonly IBajaArticuloServicio _bajaArticuloServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IMotivoBajaServicio _motivoBajaServicio;

        public _00014_ABM_BajaArticulo(TipoOp operacion, long? entidadId =null) 
            :base(operacion,entidadId)
        {
            InitializeComponent();
            _bajaArticuloServicio = new BajaArticuloServicio();
            _motivoBajaServicio =new MotivoBajaServicio();
            _articuloServicio = new ArticuloServicio();
            txtObservacion.KeyPress += Validacion.NoSimbolos;
            if (operacion == TipoOp.Eliminar || operacion == TipoOp.Modificar)
            {
                CargarDatos(entidadId);
            }
            if (operacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);
            AgregarControlesObligatorios(txtObservacion,"Observacion");
            AgregarControlesObligatorios(nudCantidad,"Cantidad");
            AgregarControlesObligatorios(cmbArticulo,"Articulo");
            AgregarControlesObligatorios(cmbMotivo,"Motiva");
            AgregarControlesObligatorios(dtpFecha,"Fecha");
            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;
            CargarComboBox(cmbArticulo, _articuloServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbMotivo, _motivoBajaServicio.Obtener(string.Empty), "Descripcion", "Id");
            dtpFecha.Focus();

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var baja = new BajaArticuloDto
            {
                ArticuloId = ((ArticuloDto) cmbArticulo.SelectedItem).Id,
                MotivoBajaId = ((MotivoBajaDto) cmbMotivo.SelectedItem).Id,
                Cantidad = nudCantidad.Value,
                Fecha = dtpFecha.Value,
                Observacion = txtObservacion.Text
            };
            var art = _articuloServicio.ObtenerPorId(((ArticuloDto) cmbArticulo.SelectedItem).Id);

            if (art.Stock >= nudCantidad.Value || art.PermiteStockNegativo)
            {
                _bajaArticuloServicio.Agregar(baja);
                return true;

            }
            else
            {
                MessageBox.Show(@"No se puede realizar la baja de articulos por stock mas bajo a la baja", "Atencion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;

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

            var baja = new BajaArticuloDto
            {
                Id=EntidadId.Value,
                ArticuloId = ((ArticuloDto)cmbArticulo.SelectedItem).Id,
                MotivoBajaId = ((MotivoBajaDto)cmbMotivo.SelectedItem).Id,
                Cantidad = nudCantidad.Value,
                Fecha = dtpFecha.Value,
                Observacion = txtObservacion.Text
            };

            var art = _articuloServicio.ObtenerPorId(((ArticuloDto)cmbArticulo.SelectedItem).Id);

            if (art.Stock >= nudCantidad.Value || art.PermiteStockNegativo)
            {
                _bajaArticuloServicio.Modificar(baja);
                return true;

            }
            else
            {
                MessageBox.Show(@"No se puede realizar la baja de articulos por stock mas bajo a la baja", "Atencion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;
            _bajaArticuloServicio.Eliminar(EntidadId);
            return true;
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
            var baja = _bajaArticuloServicio.ObtenerPorId(entidadId);
            txtObservacion.Text = baja.Observacion;
            nudCantidad.Value = baja.Cantidad;
            dtpFecha.Value = baja.Fecha;
            CargarComboBox(cmbArticulo,_articuloServicio.Obtener(string.Empty),"Descripcion","Id");
            CargarComboBox(cmbMotivo, _motivoBajaServicio.Obtener(string.Empty), "Descripcion", "Id");

        }

        private void btnAgregarMotivo_Click(object sender, EventArgs e)
        {
            var fMotivo = new _00012_ABM_MotivoBaja(TipoOp.Nuevo);
            fMotivo.ShowDialog();
            if(fMotivo.RealizoAlgunaOperacion)
                CargarComboBox(cmbMotivo,_motivoBajaServicio.Obtener(string.Empty),"Descripcion","Id");
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            var fArticulo = new _00010_ABM_Articulo(TipoOp.Nuevo);
            fArticulo.ShowDialog();
            if (fArticulo.RealizoAlgunaOperacion)
                CargarComboBox(cmbArticulo, _articuloServicio.Obtener(string.Empty), "Descripcion", "Id");

        }
    }
}
