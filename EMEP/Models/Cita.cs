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
    
    public partial class Cita
    {
        public int id { get; set; }
        public string hora { get; set; }
        public System.DateTime fecha { get; set; }
        public string ID_PACIENTE { get; set; }
        public string descripcion { get; set; }
        public int ID_CONSULTA { get; set; }
        public int estado { get; set; }
        public string observaciones { get; set; }
        public int ID_HORARIO { get; set; }
    
        public virtual Consulta Consulta { get; set; }
        public virtual Horario Horario { get; set; }
    }
}
