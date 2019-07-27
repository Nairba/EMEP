//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMEP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consulta()
        {
            this.Cita = new HashSet<Cita>();
        }
    
        public int id { get; set; }
        public int ID_MEDICO { get; set; }
        public int ID_CONSULTORIO { get; set; }
        public decimal precio { get; set; }
        public int ID_ESPECIALIDAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual Consultorio Consultorio { get; set; }
        public virtual Especialidad Especialidad { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
