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
    using System.ComponentModel.DataAnnotations;

    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            this.Consulta = new HashSet<Consulta>();
        }
        [Required]
        [Display(Name ="Correo electronico")]
        public string correo { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string p_Apellido { get; set; }
        public string s_Apellido { get; set; }
        public string contrasenna { get; set; }
        public string sexo { get; set; }
        public int estado { get; set; }
        public int ID_TIPO_USUARIO { get; set; }
        public int id { get; set; }
        public string estado_String { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
    }
}
