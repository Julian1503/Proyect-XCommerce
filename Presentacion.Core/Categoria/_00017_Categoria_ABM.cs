namespace Presentacion.Core.Categoria
{
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Categoria;
    using XCommerce.Servicio.Core.Categoria.DTOs;
    using XCommerce.Servicio.Core.Marca;
    using XCommerce.Servicio.Core.Marca.DTOs;

    public partial class _00017_Categoria_ABM : FormularioAbm
    {
        

        private readonly ICategoriaServicio _categoriaServicio;

        public _00017_Categoria_ABM(TipoOp tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _categoriaServicio = new CategoriaServicio();

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

            AgregarControlesObligatorios(txtDescripcion1, "Descripción");
            AgregarControlesObligatorios(nudSaldo, "Salario");

            Inicializador(entidadId);
        }

        private void Validaciones()
        {
            txtDescripcion1.KeyPress += Validacion.NoSimbolos;
            txtDescripcion1.KeyPress += Validacion.NoNumeros;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento

            txtDescripcion1.Focus();
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

            var categoria = _categoriaServicio.ObtenerPorId(entidadId);

            // Datos Personales
            txtDescripcion1.Text = categoria.Descripcion;
            nudSaldo.Value = categoria.SalarioCategoria;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaCategoria = new CategoriaDto
            {
                Descripcion = txtDescripcion1.Text,
                SalarioCategoria = nudSaldo.Value,
                EstaEliminado = false
            };

            _categoriaServicio.Insertar(nuevaCategoria);

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

            var CategoriaParaModificar = new CategoriaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion1.Text
            };

            _categoriaServicio.Modificar(CategoriaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _categoriaServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
