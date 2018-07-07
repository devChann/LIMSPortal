using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LIMSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        [HttpPost]
        public JToken Post([FromBody]JToken result)
        {
            return result; //CreatedAtRoute("GetCallback", result).ToString(); ;
        }

        [HttpGet(Name ="GetCallback")]
        public JToken Get(JToken item)
        {        
            return item;
        }
    }
}