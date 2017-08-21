using System;
using System.Collections.Generic;
using System.Text;

namespace ESP8266.Model.Models
{
    public class NodeModel
    {
        public int IdNode { get; set; }
        public string ChipInfo { get; set; }
        public string FlashInfo { get; set; }
	    public string Guid { get; set; }
		public bool IsActive { get; set; }
    }
}
