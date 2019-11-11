using System;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Categoria;
using XCommerce.Servicio.Core.Categoria.DTOs;
using XCommerce.Servicio.Core.Configuracion;
using XCommerce.Servicio.Core.Configuracion.DTOs;
using XCommerce.Servicio.Core.Entidad;
using XCommerce.Servicio.Core.ListaPrecio;
using XCommerce.Servicio.Core.ListaPrecio.DTOs;

namespace Presentacion.Core.Configuracion
{
    public partial class Configuracion : FormularioBase.FormularioBase
    {
        private readonly IListaPreciosServicio _listaPreciosServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly ICategoriaServicio _categoriaServicio;
        private ConfiguracionDto _configuracion;
        public bool HayLista;

        public Configuracion() : this (new ListaPreciosServicio(), new ConfiguracionServicio(),new CategoriaServicio())
        {
            InitializeComponent();
            _configuracion = _configuracionServicio.Obtener();

            if (_configuracion != null)
            {
                CargarConfiguraciones();
                return;
            }

            if (HayLista)
                Inicializar();
        }

        public Configuracion(IListaPreciosServicio listaPreciosServicio, IConfiguracionServicio configuracionServicio,ICategoriaServicio categoriaServicio) : base()
        {
            _categoriaServicio = categoriaServicio;
            _listaPreciosServicio = listaPreciosServicio;
            HayLista = _listaPreciosServicio.HayListas();
            _configuracionServicio = configuracionServicio;
        }

        private void CargarConfiguraciones()
        {
            CargarComboBox(cmbListaDelivery, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbListaDelivery.SelectedValue = _configuracion.ListaDeliveryId;
            CargarComboBox(cmbListaKiosco, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbListaKiosco.SelectedValue = _configuracion.ListaKioscoId;
            CargarComboBox(cmbCadete, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbCadete.SelectedValue = _configuracion.CadeteId;
            CargarComboBox(cmbMozo, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");
            cmbMozo.SelectedValue = _configuracion.MozoId;
        }

        private void Inicializar()
        {
            CargarComboBox(cmbListaDelivery, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbListaKiosco, _listaPreciosServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbCadete, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbMozo, _categoriaServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        private void btnListas_Click(object sender, EventArgs e)
        {

            var configuracionNueva = new ConfiguracionDto
            {
                ListaKioscoId = ((ListaPreciosDto)cmbListaKiosco.SelectedItem).Id,
                ListaKioscoDescripcion = ((ListaPreciosDto)cmbListaKiosco.SelectedItem).Descripcion,
                ListaDeliveryDescripcion = ((ListaPreciosDto)cmbListaDelivery.SelectedItem).Descripcion,
                ListaDeliveryId = ((ListaPreciosDto)cmbListaDelivery.SelectedItem).Id,
                CadeteId = ((CategoriaDto)cmbCadete.SelectedItem).Id,
                CategoriaCadeteDescripcion = ((CategoriaDto)cmbCadete.SelectedItem).Descripcion,
                CategoriaMozoDescripcion = ((CategoriaDto)cmbMozo.SelectedItem).Descripcion,
                MozoId = ((CategoriaDto)cmbMozo.SelectedItem).Id,


            };
            if (_configuracion == null)
            {
                _configuracionServicio.Agregar(configuracionNueva);
            }
            else
            {
                configuracionNueva.Id = _configuracion.Id;
                _configuracionServicio.Modificar(configuracionNueva);
            }
            MessageBox.Show("Resultado satisfactorio", "Todo salio bien");
            Entidad.ListaPrecioDeliveryId = configuracionNueva.ListaDeliveryId;
            Entidad.ListaPrecioKioscoId = configuracionNueva.ListaKioscoId;
            Entidad.CategoriaCadeteId = configuracionNueva.CadeteId;
            Entidad.CategoriaMozoId = configuracionNueva.MozoId;
            Entidad.ListaPrecioDeliveryDescripcion = configuracionNueva.ListaDeliveryDescripcion;
            Entidad.ListaPrecioKioscoDescripcion = configuracionNueva.ListaKioscoDescripcion;
            Entidad.CategoriaMozoDescripcion = configuracionNueva.CategoriaMozoDescripcion;
            Entidad.CategoriaCadeteDescripcion = configuracionNueva.CategoriaCadeteDescripcion;
        }
    }
}
