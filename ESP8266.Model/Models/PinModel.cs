using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP8266.Model.Models
{
	public class PinModel
	{
		public int PinNumber { get; set; }
		public bool IsDigital { get; set; }
		public float Value { get; set; }
		public bool State { get; set; }
		public int IdNode { get; set; }
		public virtual NodeModel t_node { get; set; }
	}
}
