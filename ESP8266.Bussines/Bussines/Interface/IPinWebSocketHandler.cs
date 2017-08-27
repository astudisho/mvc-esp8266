using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using ESP8266.Model.Models;

namespace ESP8266.Bussines.Bussines.Interface
{
	public interface IPinWebSocketHandler
	{
		Task RegisterWebSocket(AspNetWebSocketContext aspNetWebSocketContext);
		Task SendMessage(string uuid, string message);
		//static Task<WebSocketModel> GetWebSocket(string uuid);
	}
}
