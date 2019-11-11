namespace Presentacion.Core.Usuario
{
    using System;
    using System.Windows.Forms;
    using XCommerce.Servicio.Seguridad.Usuario;
    using XCommerce.Servicio.Seguridad.Usuario.DTOs;

    public partial class _00015_Usuarios : FormularioBase.FormularioBase
    {
        public bool RealizoAlgunaOperacion { get; set; }

        private readonly IUsuarioServicio _usuarioServicio;
        private UsuarioDto _usuarioDto;

        public _00015_Usuarios()
        {
            InitializeComponent();
            _usuarioServicio = new UsuarioServicio();
            _usuarioDto = new UsuarioDto();
            btnActualizar.Image = Constantes.ImagenesSistema.Actualizar;
            btnCambiarEstado.Image = Constantes.ImagenesSistema.Bloquear;
            btnNuevo.Image = Constantes.ImagenesSistema.CrearUsuario;
            RealizoAlgunaOperacion = false;
            menuAccesoRapido.BackColor = Constantes.Color.ColorMenu;
        }

        private void FormatearGrilla(DataGridView grillita)
        {
            for (var i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            grillita.Columns["Nombre"].Visible = true;
           // grillita.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grillita.Columns["Nombre"].HeaderText = @"Usuario";
            grillita.Columns["Nombre"].Width = 200;
            grillita.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grillita.Columns["ApyNom"].Visible = true;
            grillita.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grillita.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            grillita.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grillita.Columns["EstaBloqueadoStr"].Visible = true;
            //grillita.Columns["EstaBloqueadoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grillita.Columns["EstaBloqueadoStr"].HeaderText = @"Bloqueado";
            grillita.Columns["EstaBloqueadoStr"].Width = 100;
            grillita.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Actualizar(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _usuarioServicio.Obtener(cadenaBuscar);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(txtBuscar.Text);
        }

        private void _00015_Usuarios_Load(object sender, EventArgs e)
        {
            Actualizar(string.Empty);
            FormatearGrilla(dgvGrilla);
            if (dgvGrilla.RowCount==0)
            {
                _usuarioDto = null;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar(string.Empty);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _usuarioDto = (UsuarioDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _usuarioDto = null;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_usuarioDto == null)
            {
                MessageBox.Show("Por favor seleccione un registro");
                return;
            }
            if (_usuarioDto.Nombre != "NO ASIGNADO")
            {
                MessageBox.Show("La Persona seleccionada ya tiene Usuario");
                return;

            }
            _usuarioServicio.Crear(_usuarioDto.PersonaId,_usuarioDto.ApellidoPersona, _usuarioDto.NombrePersona);
            Actualizar(string.Empty);
            RealizoAlgunaOperacion = true;
        }

        private void btCambiarEstado_Click(object sender, EventArgs e)
        {
            if (_usuarioDto == null)
            {
                MessageBox.Show("Por favor seleccione un registro");
                return;
            }

            if (_usuarioDto.Nombre == "NO ASIGNADO")
            {
                MessageBox.Show("La Persona seleccionada no tiene Usuario");
                return;
            }

            _usuarioServicio.CambiarEstado(_usuarioDto.Nombre,!_usuarioDto.EstaBloqueado);

            MessageBox.Show(_usuarioDto.EstaBloqueado ? @"El usuario fue desbloqueado" : @"El usuario fue bloqueado");
            Actualizar(string.Empty);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
