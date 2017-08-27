using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;
using ESP8266.Bussines.Bussines.Interface;
using ESP8266.Bussines.Util;
using ESP8266.Model.Models;
using log4net;


namespace ESP8266_Temperature.Controllers
{
	[System.Web.Http.RoutePrefix("api/Pin")]
	public class PinController : ApiController
	{
		private readonly ILog _log;
		private static WebSocket _ws;
		private readonly IPinWebSocketHandler _webSocketHandler;

		public PinController(ILog log, IPinWebSocketHandler webSocketHandler)
		{
			_log = log;
			_webSocketHandler = webSocketHandler;
		}

		[HttpGet]
		[Route("Connect")]
		public async Task<IHttpActionResult> Connect(string flashInfo)
		{
			if (!HttpContext.Current.IsWebSocketRequest || string.IsNullOrWhiteSpace(flashInfo))
				return NotFound();

			HttpContext.Current.Items.Add(Constants.WebSockets.Uuid, flashInfo);
			//HttpContext.Current.AcceptWebSocketRequest(HandleWebSocket);
			HttpContext.Current.AcceptWebSocketRequest(_webSocketHandler.RegisterWebSocket);

			return StatusCode(HttpStatusCode.SwitchingProtocols);
		}

		[HttpGet]
		[Route("Switch")]
		public async Task<IHttpActionResult> Switch(string flashInfo = "")
		{
			var sendDataBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(flashInfo + ": Message number --> ON//OFF "));
			await _ws.SendAsync(sendDataBuffer, WebSocketMessageType.Text, true, CancellationToken.None);

			return Ok();
		}

		[HttpGet]
		[Route("Send")]
		public async Task<IHttpActionResult> Send(string uuid, string message)
		{
			await _webSocketHandler.SendMessage(uuid, message);
			return Ok();
		}

		//[HttpPost]
		//[Route("UpdatePinState")]
		//public async Task<IHttpActionResult> UpdatePinState(PinModel model)
		//{
		//	await _webSocketHandler.
		//}
	}
}