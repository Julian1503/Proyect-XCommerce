namespace Presentacion.Core.Salon
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Helpers;
    using XCommerce.Servicio.Core.Salon;
    using XCommerce.Servicio.Core.Salon.DTOs;

    public partial class _00027_Salon : FormularioConsulta
    {
        private readonly ISalonServicio _salonServicio; 

        public _00027_Salon()
            : this(new SalonServicio())
        {
            InitializeComponent();
        }

        public _00027_Salon(ISalonServicio salonServicio)
        {
            _salonServicio = salonServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Salon";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _salonServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fSalonAbm = new _00028_ABM_Salon(TipoOp.Nuevo);
            fSalonAbm.ShowDialog();

            ActualizarSegunOperacion(fSalonAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            try
            {
                if (!((SalonDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fSalonAbm = new _00028_ABM_Salon(TipoOp.Modificar, EntidadId);
                    fSalonAbm.ShowDialog();

                    ActualizarSegunOperacion(fSalonAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El Salon se encuetra eliminado", @"Atención", MessageBoxButtons.OK,
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
                if (!((SalonDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fSalonAbm = new _00028_ABM_Salon(TipoOp.Eliminar, EntidadId);

                    fSalonAbm.ShowDialog();

                    ActualizarSegunOperacion(fSalonAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El Salon se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existen datos cargados");
            }
            
        }


        //=================================== METODOS PRIVADOS ===================================//

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
