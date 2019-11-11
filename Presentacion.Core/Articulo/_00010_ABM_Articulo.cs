namespace Presentacion.Core.Articulo
{
    using System.Drawing;
    using System.Windows.Forms;
    using Constantes;
    using FormularioBase;
    using Helpers;
    using Marca;
    using Rubro;
    using XCommerce.Servicio.Core.Articulo;
    using XCommerce.Servicio.Core.Articulo.DTOs;
    using XCommerce.Servicio.Core.Marca;
    using XCommerce.Servicio.Core.Marca.DTOs;
    using XCommerce.Servicio.Core.Rubro;
    using XCommerce.Servicio.Core.Rubro.DTOs;

    public partial class _00010_ABM_Articulo : FormularioAbm
    {
         private readonly IRubroServicio _rubroServicio;
         private readonly IMarcaServicio _marcaServicio;
        private readonly IArticuloServicio _articuloServicio;
        public _00010_ABM_Articulo(TipoOp operacion, long? entidadId = null)
            :base(operacion,entidadId)
        {
            InitializeComponent();
            _rubroServicio = new RubroServicio();
            _marcaServicio = new MarcaServicio();
            _articuloServicio = new ArticuloServicio();

            Validaciones();

            if (TipoOp.Eliminar == operacion || TipoOp.Modificar == operacion)
            {
                CargarDatos(entidadId);
            }
            if (operacion == TipoOp.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);
            AgregarControlesObligatorios(txtCodigo,"Codigo");
            AgregarControlesObligatorios(txtCodigoBarra,"Codigo de Barra");
            AgregarControlesObligatorios(txtDescripcion,"Descripcion");
            AgregarControlesObligatorios(cmbMarca,"Marca");
            AgregarControlesObligatorios(cmbRubro,"Rubro");
            AgregarControlesObligatorios(txtAbreviatura, "Abreviatura");
            AgregarControlesObligatorios(nudStockMax, "Stock Maximo");
            AgregarControlesObligatorios(nudStockMin, "Stock Minimo");
            AgregarControlesObligatorios(nudStock, "Stock");




            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtCodigo.KeyPress += Validacion.NoSimbolos;
            txtCodigo.KeyPress += Validacion.NoLetras;

            txtCodigoBarra.KeyPress += Validacion.NoLetras;
            txtCodigoBarra.KeyPress += Validacion.NoSimbolos;
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
            

            var articuloCargar = _articuloServicio.ObtenerPorId(entidadId);
            nudLimiteVenta.Enabled = false;
            txtAbreviatura.Text = articuloCargar.Abreviatura;
            txtCodigo.Text = articuloCargar.Codigo;
            txtCodigoBarra.Text = articuloCargar.CodigoBarra;
            if (articuloCargar.PermiteStockNegativo)
            {
                nudStock.Minimum = -100;
            }
            else
            {
                nudStock.Minimum = 0;
            }
            nudStock.Value = articuloCargar.Stock;
            txtDescripcion.Text = articuloCargar.Descripcion;
            nudStockMax.Value = articuloCargar.StockMaximo;
            nudStock.Maximum = nudStockMax.Value;
            nudStockMin.Value = articuloCargar.StockMinimo;
            cbDescuentoStock.Checked = articuloCargar.DescuentaStock;
            
            cbPermiteStockNegativo.Checked = articuloCargar.PermiteStockNegativo;
            
            cbDiscontinuado.Checked = articuloCargar.EstaDiscontinuado;
            cbLimiteVenta.Checked = articuloCargar.ActivarLimiteVenta;
            if (cbLimiteVenta.Checked)
            {
                nudLimiteVenta.Value = articuloCargar.LimiteVenta;
                nudLimiteVenta.Enabled = true;

            }
            else
            {
                nudLimiteVenta.Value = 0;

            }
            imgArticulo.Image = ImagenDb.Convertir_Bytes_Imagen(articuloCargar.Foto);
            CargarComboBox(cmbMarca,_marcaServicio.Obtener(string.Empty),"Descripcion","Id");
            CargarComboBox(cmbRubro,_rubroServicio.Obtener(string.Empty),"Descripcion","Id");
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;
            nudLimiteVenta.Enabled = false;
            lblCantidad.Enabled = false;
            imgArticulo.Image = ImagenesSistema.ProductoVacio;
            CargarComboBox(cmbMarca,_marcaServicio.Obtener(string.Empty),"Descripcion","Id");
            CargarComboBox(cmbRubro,_rubroServicio.Obtener(string.Empty),"Descripcion","Id");
            nudStockMax.Value = 1000;
            nudStock.Maximum = nudStockMax.Value;

            txtCodigo.Text = _articuloServicio.SiguienteCodigoArticulo();

            txtCodigoBarra.Focus();
            

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var articuloNuevo = new ArticuloDto
            {
                Abreviatura = txtAbreviatura.Text,
                ActivarLimiteVenta = cbLimiteVenta.Checked,
                Codigo = txtCodigo.Text,
                CodigoBarra = txtCodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                DescuentaStock = cbDescuentoStock.Checked,
                Detalle = txtDetalle.Text,
                EstaDiscontinuado = cbDiscontinuado.Checked,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgArticulo.Image),
                LimiteVenta = nudLimiteVenta.Value,
                PermiteStockNegativo = cbPermiteStockNegativo.Checked,
                MarcaId = ((MarcaDto) cmbMarca.SelectedItem).Id,
                RubroId = ((RubroDto) cmbRubro.SelectedItem).Id,
                StockMaximo = nudStockMax.Value,
                Stock =  nudStock.Value,
                StockMinimo = nudStockMin.Value
            };
            _articuloServicio.Agregar(articuloNuevo);

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

            var articuloNuevo = new ArticuloDto
            {
                Id =(int)EntidadId.Value,
                Abreviatura = txtAbreviatura.Text,
                ActivarLimiteVenta = cbLimiteVenta.Checked,
                Codigo = txtCodigo.Text,
                CodigoBarra = txtCodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                DescuentaStock = cbDescuentoStock.Checked,
                Detalle = txtDetalle.Text,
                EstaDiscontinuado = cbDiscontinuado.Checked,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgArticulo.Image),
                LimiteVenta = nudLimiteVenta.Value,
                PermiteStockNegativo = cbPermiteStockNegativo.Checked,
                MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,
                RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,
                Stock = nudStock.Value,
                StockMaximo = nudStockMax.Value,
                StockMinimo = nudStockMin.Value
            };
            _articuloServicio.Modificar(articuloNuevo);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _articuloServicio.Eliminar(EntidadId.Value);

            return true;
        }

        public override void EjecutarComando()
        {
            base.EjecutarComando();

            if (TipoOperacion == TipoOp.Nuevo)
                txtCodigo.Text = _articuloServicio.SiguienteCodigoArticulo();
        }

        private void cbLimiteVenta_CheckedChanged(object sender, System.EventArgs e)
        {
            nudLimiteVenta.Enabled = cbLimiteVenta.Checked ? true : false;
            nudLimiteVenta.Value = !cbLimiteVenta.Checked ? 0 : 1;
            lblCantidad.Enabled = cbLimiteVenta.Checked ? true : false;
        }

        private void btnAgregarImagen_Click(object sender, System.EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgArticulo.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgArticulo.Image = Constantes.ImagenesSistema.ProductoVacio;
                }
            }
            else
            {
                imgArticulo.Image = Presentacion.Constantes.ImagenesSistema.ProductoVacio;
            }
        }

        private void btnAgregarMarca_Click(object sender, System.EventArgs e)
        {
            var fNuevaMarca = new _00017_Marca_ABM(TipoOp.Nuevo);
            fNuevaMarca.ShowDialog();
            if (!fNuevaMarca.RealizoAlgunaOperacion) return;
            CargarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        private void btnAgregarRubro_Click(object sender, System.EventArgs e)
        {
            var fNuevoRubro = new _00019_Rubro_ABM(TipoOp.Nuevo);
            fNuevoRubro.ShowDialog();

            if (!fNuevoRubro.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbRubro, _rubroServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        private void cbPermiteStockNegativo_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbPermiteStockNegativo.Checked)
            {
                nudStock.Minimum = -100;
            }
            else
            {
                nudStock.Minimum = 0;
                nudStock.Value = 0;
            }
        }

        private void nudStockMax_ValueChanged(object sender, System.EventArgs e)
        {
            nudStock.Maximum = nudStockMax.Value;
        }

        private void nudStockMin_ValueChanged(object sender, System.EventArgs e)
        {
            nudStock.Minimum = nudStockMin.Value;
        }
    }
}
