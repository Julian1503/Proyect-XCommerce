//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XCommerce.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListaPrecio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaPrecio()
        {
            this.Precios = new HashSet<Precio>();
            this.Salon = new HashSet<Salon>();
            this.ConfiguracionDelivery = new HashSet<Configuracion>();
            this.ConfiguracionKiosco = new HashSet<Configuracion>();
        }
    
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Rentabilidad { get; set; }
        public bool EstaEliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Precio> Precios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salon> Salon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuracion> ConfiguracionDelivery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuracion> ConfiguracionKiosco { get; set; }
    }
}
