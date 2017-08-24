using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using Microsoft.AspNet.SignalR.WebSockets;

namespace ESP8266.Bussines.Bussines.Implementation
{
	public class PinWebSocketaHandler : WebSocketHandler
	{
		private static readonly List<AspNetWebSocket> _webSocketsList = new List<AspNetWebSocket>();

		public PinWebSocketaHandler(int? maxIncomingMessageSize) : base(maxIncomingMessageSize)
		{

		}

		public override void OnMessage(string message)
		{
			base.OnMessage(message);
		}
	}
}