
namespace Presentacion.Core.Empresa
{
    using System;
    using Helpers;
    using XCommerce.Servicio.Core.CondicionIva;
    using XCommerce.Servicio.Core.Empresa;
    using XCommerce.Servicio.Core.Localidad;
    using XCommerce.Servicio.Core.Provincia;

    public partial class _00042_DatosEmpresa : FormularioBase.FormularioBase
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IProvinciaServicio    _provinciaServicio;
        private readonly ILocalidadServicio    _localidadServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;
        public _00042_DatosEmpresa() : this(new EmpresaServicio(),new ProvinciaServicio(),new LocalidadServicio(),new CondicionIvaServicio())
        {
            InitializeComponent();
            toolStrip1.BackColor = Constantes.Color.ColorMenu;
            btnModificar.Image = Constantes.ImagenesSistema.Modificar;
            btnSalir.Image = Constantes.ImagenesSistema.Salir;
           
    }
        public _00042_DatosEmpresa(IEmpresaServicio empresaServicio, IProvinciaServicio provinciaServicio,ILocalidadServicio localidadServicio,ICondicionIvaServicio condicionIvaServicio) 
        {
            _empresaServicio = empresaServicio;
            _provinciaServicio = provinciaServicio;
            _localidadServicio = localidadServicio;
            _condicionIvaServicio = condicionIvaServicio;
        }

        private void _00042_DatosEmpresa_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            var empresa = _empresaServicio.Obtener();
            lblContenidoTelefono.Text = empresa.Telefono;
            lblContenidoCuit.Text = empresa.Cuit;
            lblContenidoRazonSocial.Text = empresa.RazonSocial;
            lblContenidoEmail.Text = empresa.Mail;
            lblContenidoSucursal.Text = empresa.Sucursal;
            imgLogo.Image = ImagenDb.Convertir_Bytes_Imagen(empresa.Logo);
            lblContenidoNombreFantasia.Text = empresa.NombreFantasia;
            lblContenidoCondicionIva.Text = _condicionIvaServicio.ObtenerPorId(empresa.CondicionIvaId).Descripcion;
            lblContenidoLocalidad.Text = _localidadServicio.ObtenerPorId(empresa.LocalidadId).Descripcion;
            lblContenidoProvincia.Text = _provinciaServicio.ObtenerPorId(empresa.ProvinciaId).Descripcion;
            lblContenidoBarrio.Text = empresa.Barrio;
            lblContenidoDireccion.Text = $"{empresa.Calle} {empresa.Numero}";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var fEmp = new _00020_Empresa();
            fEmp.ShowDialog();
            if (fEmp.RealizoOperacion) Actualizar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
