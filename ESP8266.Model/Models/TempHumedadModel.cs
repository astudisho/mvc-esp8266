using System;
using System.Collections.Generic;
using System.Text;

namespace ESP8266.Model.Models
{
    public class TempHumedadModel
    {
        public int IdTempHumedad { get; set; }
        public float Temperatura { get; set; }
        public float Humedad { get; set; }
        public int IdNode { get; set; }
        public DateTime HoraFecha { get; set; }
    }

	public class TempHumedadAddModel : TempHumedadModel
	{
		public string ChipInfo { get; set; }
	}
}
