namespace XCommerce.Servicio.Core.Empresa
{
    using DTOs;

    public interface IEmpresaServicio
    {
        long? Agregar(EmpresaDto empresa);
        EmpresaDto Obtener();
        void Modificar(EmpresaDto empresa);
        bool HayDatos();

    }
}
