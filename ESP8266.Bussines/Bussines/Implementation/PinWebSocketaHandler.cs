using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
//using System.Web.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;
using ESP8266.Bussines.Bussines.Interface;
using ESP8266.Bussines.Util;
using ESP8266.Model.Models;
using log4net;
using Microsoft.AspNet.SignalR.WebSockets;

namespace ESP8266.Bussines.Bussines.Implementation
{
	public class PinWebSocketaHandler : IPinWebSocketHandler
	{
		private static readonly Dictionary<string,WebSocket> _webSocketsList = new Dictionary<string,WebSocket>();

		private readonly INode _node;
		private readonly log4net.ILog _log;

		public PinWebSocketaHandler(INode node, ILog log)
		{
			_node = node;
			_log = log;
		}

		public async Task RegisterWebSocket(AspNetWebSocketContext aspNetWebSocketContext)
		{
			var webSocket = aspNetWebSocketContext.WebSocket;
			var flashInfo = aspNetWebSocketContext.Items[Constants.WebSockets.Uuid].ToString();

			var ctkSource = new CancellationTokenSource();
			
			var receivedDataBuffer = new ArraySegment<Byte>(new byte[Constants.WebSockets.MaxBufferSize]);

			try
			{
				//OnConnect
				//Registed WebSocket
				_webSocketsList.Add(flashInfo, webSocket);

				//TODO Add a method to return node with following identifier

				_log.Debug(flashInfo);

				//TODO register websocket on an object accesible from PinBussines
				//OnMessage
				while (webSocket.State.Equals(WebSocketState.Open))
				{
					await webSocket.ReceiveAsync(receivedDataBuffer, ctkSource.Token);
					var receivedMessage = Encoding.UTF8.GetString(receivedDataBuffer.Array, Constants.WebSockets.InitialBufferIndex, receivedDataBuffer.Count);
					receivedMessage = receivedMessage.Replace("\0",String.Empty);
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
				_webSocketsList.Remove(flashInfo);
				_log.Debug(webSocket);
			}
		}
		
		public async Task SendMessage(string uuid, string message)
		{
			try
			{
				var ws = _webSocketsList[uuid];
				var messageToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
				await ws.SendAsync(messageToSend, WebSocketMessageType.Text, true, CancellationToken.None);
			}
			catch (Exception e)
			{
				_log.Error(e);
				throw;
			}
		}

		static async Task<WebSocketModel> GetWebSocket(string uuid)
		{
			try
			{
				return new WebSocketModel()
				{
					WebSocket = _webSocketsList[uuid],
				};
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}