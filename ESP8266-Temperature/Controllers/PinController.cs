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
using ESP8266.Model.Models;
using log4net;


namespace ESP8266_Temperature.Controllers
{
	[System.Web.Http.RoutePrefix("api/Pin")]
	public class PinController : ApiController
	{
		private readonly ILog _log;
		private static WebSocket _ws;
		
		public PinController(ILog log)
		{
			_log = log;
		}

		[HttpGet]
		[Route("Connect")]
		public async Task<IHttpActionResult> Connect(string flashInfo)
		{
			if (!HttpContext.Current.IsWebSocketRequest || string.IsNullOrWhiteSpace(flashInfo))
				return NotFound();

			HttpContext.Current.Items.Add("FlashInfo", flashInfo);
			HttpContext.Current.AcceptWebSocketRequest(HandleWebSocket);
			
			
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

		private async Task HandleWebSocket(AspNetWebSocketContext aspNetWebSocketContext)
		{
			var webSocket = aspNetWebSocketContext.WebSocket;
			_ws = webSocket;
			var ctkSource = new CancellationTokenSource();

			try
			{
				const int maxBufferSize = 1024;
				var receivedDataBuffer = new ArraySegment<Byte>(new byte[maxBufferSize]);
				
				var i = 0;

				//TODO Add a method to return node with following identifier
				var flashInfo = aspNetWebSocketContext.Items["FlashInfo"];
				_log.Debug(flashInfo);

				//TODO register websocket on an object accesible from PinBussines

				while (webSocket.State.Equals(WebSocketState.Open))
				{
					await webSocket.ReceiveAsync(receivedDataBuffer, ctkSource.Token);
					var receivedMessage = Encoding.UTF8.GetString(receivedDataBuffer.Array, 0, receivedDataBuffer.Count);
					_log.Debug(receivedMessage);
				}
			}
			catch (Exception e)
			{
				_log.Error(e);
				throw;
			}
			finally
			{
				//TODO Delete registered WebSocket
				ctkSource.Cancel();
				_log.Debug(webSocket);
			}
		}
	}
}