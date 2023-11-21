using Api.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{   /*
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly ISortBusiness _sortBusiness;

        public SortController(ISortBusiness sortBusiness)
        {
            _sortBusiness = sortBusiness;
        }

        // GET: api/<SortController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
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
        }
    }
    */
}
