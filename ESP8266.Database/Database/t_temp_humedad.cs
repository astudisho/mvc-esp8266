//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESP8266.Database.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_temp_humedad
    {
        public int IdTempHumedad { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Humedad { get; set; }
        public System.DateTime HoraFecha { get; set; }
        public int IdNode { get; set; }
    
        public virtual t_node t_node { get; set; }
    }
}
