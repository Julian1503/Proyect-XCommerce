namespace Presentacion.Core.Proveedor
{
    using FormularioBase;
    using Helpers;
    using System.Windows.Forms;
    using XCommerce.Servicio.Core.Proveedor;
    using XCommerce.Servicio.Core.Proveedor.DTOs;

    public partial class _00031_Proveedores : FormularioConsulta
    {
        private readonly IProveedorServicio _proveedorServicio;

        public _00031_Proveedores()
            : this(new ProveedorServicio())
        {
            InitializeComponent();
        }

        public _00031_Proveedores(IProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Contacto"].Visible = true;
            grilla.Columns["Contacto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; grilla.Columns["Contacto"].HeaderText = @"Contacto";
            grilla.Columns["Contacto"].HeaderText = @"Contacto";
            grilla.Columns["Contacto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Telefono"].Visible = true;
            grilla.Columns["Telefono"].Width = 150;
            grilla.Columns["Telefono"].HeaderText = @"Telefono";
            grilla.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["RazonSocial"].Visible = true;
            grilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; grilla.Columns["Contacto"].HeaderText = @"Contacto";
            grilla.Columns["RazonSocial"].HeaderText = @"Email";
            grilla.Columns["RazonSocial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _proveedorServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fProveedorAbm = new _00032_Proveedores_ABM(TipoOp.Nuevo);
            fProveedorAbm.ShowDialog();

            ActualizarSegunOperacion(fProveedorAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((ProveedorDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fProveedorAbm = new _00032_Proveedores_ABM(TipoOp.Modificar, EntidadId);
                fProveedorAbm.ShowDialog();

                ActualizarSegunOperacion(fProveedorAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Proveedor se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!EntidadId.HasValue) { MessageBox.Show("¡La grilla esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (!((ProveedorDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fProveedorAbm = new _00032_Proveedores_ABM(TipoOp.Eliminar, EntidadId);

                fProveedorAbm.ShowDialog();

                ActualizarSegunOperacion(fProveedorAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El Proveedor se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ======================================================================================= //

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
