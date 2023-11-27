using Api.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.OpenApi.Extensions;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly ISortBusiness _sortBusiness;

        public SortController(ISortBusiness sortBusiness)
        {
            _sortBusiness = sortBusiness;
        }

        [HttpGet]
        [Route("sort-options")]
        public Dictionary<string, int> GetSortSelections()
        {
            SortOptionsEnum[] enumNames = Enum.GetValues<SortOptionsEnum>();
            Dictionary<string, int> soDic = new Dictionary<string, int>();
            Array.ForEach(enumNames, so =>soDic.Add(Enum.GetName(so), (int)so));

            return soDic;
        }
    }
}
