using Api.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;

using WebSocketHelpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/sort-websocket")]
    [ApiController]
    public class SortWebSocketsController : ControllerBase
    {
        private readonly ISortBusiness _sortBusiness;
        private readonly IWebSocketHelper _webSocketHelper;

        public SortWebSocketsController(ISortBusiness sortBusiness, IWebSocketHelper webSocketHelper)
        {
            _sortBusiness = sortBusiness;
            _webSocketHelper = webSocketHelper;
        }

        // GET: api/<SortController>
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await _webSocketHelper.Sort(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

            /*

            var queryArr = Request.QueryString.Value.Split("&");
            var type = "basic_sort";
            foreach(var q in queryArr)
            {
                var qArr = q.Split("=");
                if (qArr[0].Contains("type"))
                {
                    type = qArr[1];
                    break;
                }
            }

            return await _sortBusiness.OperationTypeBy(type);     

            */

        }
    }
}
