namespace Presentacion.Core.Mesa
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Mesa;
    using XCommerce.Servicio.Core.Mesa.DTOs;

    public partial class _00035_Mesa : FormularioConsulta
    {
        private readonly IMesaServicio _mesaServicio;

        public _00035_Mesa()
            : this(new MesaServicio())
        {
            InitializeComponent();
        }

        public _00035_Mesa(IMesaServicio mesaServicio)
        {
            _mesaServicio = mesaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Numero"].Visible = true;
            grilla.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Numero"].HeaderText = @"Numero";
            grilla.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoMesaStr"].Visible = true;
            grilla.Columns["EstadoMesaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoMesaStr"].HeaderText = @"Estado";
            grilla.Columns["EstadoMesaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["SalonNombre"].Visible = true;
            grilla.Columns["SalonNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["SalonNombre"].HeaderText = @"Salon";
            grilla.Columns["SalonNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _mesaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new _00036_ABM_Mesa(TipoOp.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            try
            {
                if (!((MesaDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new _00036_ABM_Mesa(TipoOp.Modificar, EntidadId);
                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"La Mesa se encuetra Eliminada", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existen datos cargados");
            }            
        }

        public override void EjecutarEliminar()
        {
            try
            {
                if (!((MesaDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new _00036_ABM_Mesa(TipoOp.Eliminar, EntidadId);

                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"La Mesa se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No existen datos cargados");
            }            
        }

        //========================================= METODOS PRIVADOS =========================================//

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
