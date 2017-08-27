using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ESP8266.Model.Models
{
	public class WebSocketModel
	{
		public WebSocket WebSocket { get; set; }
		public CancellationTokenSource CancellationTokenSource { get; set; }

	}
}
