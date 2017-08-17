using System;
using System.Collections.Generic;
using System.Text;

namespace ESP8266.Model.Models
{
    class Node
    {
        public int IdNode { get; set; }
        public string ChipInfo { get; set; }
        public string FlashInfo { get; set; }
        public bool IsActive { get; set; }
    }
}
