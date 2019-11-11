namespace XCommerce.Servicio.Core.Mesa.DTOs
{
    using AccesoDatos;
    using Base;

    public class MesaDto : BaseDto
    {
        public int Numero { get; set; }

        public string Descripcion { get; set; }
    
        public string SalonNombre { get; set; }

        public long SalonId { get; set; }

        public EstadoMesa EstadoMesa { get; set; }

        public string EstadoMesaStr => EstadoMesa == EstadoMesa.Abierta ? "Abierta" :
            EstadoMesa == EstadoMesa.Cerrada ? "Cerrada" :
            EstadoMesa == EstadoMesa.FueraServicio ? "Fuera de Servicio" : "Reservado";

        public TipoMesa TipoMesa { get; set; }

        public string TipoMesaStr => TipoMesa == TipoMesa.Cuadrada ? "Cuadrada" : "Redonda";
    }
}
