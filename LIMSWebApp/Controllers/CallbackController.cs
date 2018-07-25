using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMSWebApp.ViewModels.MpesaModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LIMSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger<CallbackController> _log;

        public CallbackController(ILogger<CallbackController> log)
        {
            _log = log;
        }

        [HttpPost]
        public JToken Post([FromBody]JToken result)
        {
            _log.LogInformation(result.ToString());          

            var response = JsonConvert.DeserializeObject<STKResponse>(result.ToString());


            Console.WriteLine($"This What chann wants to see: {response.Body.stkCallback.CheckoutRequestID}");

            Console.WriteLine($"This is the callback from mpesa daraja api: {result.ToString()}");

            return result;             
        }

        [HttpGet]
        public JToken Get(JToken item)
        {        
            return item;
        }
    }
}