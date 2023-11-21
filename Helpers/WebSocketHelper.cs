using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

using Api.Business;
using Microsoft.AspNetCore.Http.Connections;

namespace WebSocketHelpers
{

    public interface IWebSocketHelper 
    {
        Task Sort(WebSocket webSocket);
        public static async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult receiveResult = null;

            receiveResult = await webSocket.ReceiveAsync(
                                  new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!receiveResult.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(
                        new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                        receiveResult.MessageType,
                        receiveResult.EndOfMessage,
                        CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }
    }

    public class WebSocketHelper : IWebSocketHelper
    {
        private readonly ISortBusiness _sortBusiness;

        public WebSocketHelper(ISortBusiness sortBusiness)
        {
            _sortBusiness = sortBusiness;
        }

        public async Task Sort(WebSocket webSocket)
        {          
            WebSocketReceiveResult receiveResult = null;

            Action<string[]> action = async (string[] sorted) =>
            {
                string sortedArrJsn = JsonSerializer.Serialize(sorted);
                byte[] buffer = Encoding.UTF8.GetBytes(sortedArrJsn);
                Thread.Sleep(1000);
                await webSocket.SendAsync(
                        new ArraySegment<byte>(buffer),
                        WebSocketMessageType.Binary,
                        true,
                        CancellationToken.None);
            };

            string[] sortedArr = await _sortBusiness.OperationTypeBy("basic_sort", action);
            string sortedArrJsn = JsonSerializer.Serialize(sortedArr);
            byte[] buffer = Encoding.UTF8.GetBytes(sortedArrJsn);
            
            await webSocket.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                "closed",
                CancellationToken.None);
        }
    }
}