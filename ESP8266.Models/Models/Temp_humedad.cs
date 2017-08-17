using System;
using System.Collections.Generic;
using System.Text;

namespace ESP8266.Models.Models
{
    class Temp_humedad
    {
        public int IdTempHumedad { get; set; }
        public float Temperatura { get; set; }
        public float Humedad { get; set; }
        public int IdNode { get; set; }
        public DateTime HoraFecha { get; set; }
    }
}
