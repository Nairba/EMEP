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
    
    public partial class Administrador
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int estado { get; set; }
        public int ID_TIPO_USUARIO { get; set; }
    
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }

        public bool estad { get; set; }
        public string estado_String { get; set; }
    }
}
