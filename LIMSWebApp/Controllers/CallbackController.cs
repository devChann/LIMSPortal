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

            var stkresult = result.ToString();

            //_log.LogInformation(stkresult);

            STKResponse response = JsonConvert.DeserializeObject<STKResponse>(stkresult);

            Console.WriteLine($"This is What chann wants to see: {response.Body.StkCallback.CheckoutRequestID}");

            List<Item> list = response.Body.StkCallback.CallbackMetadata.Item.ToList();

            string AmountPaid = "";

            foreach(Item item in list)
            {
                if(item.Name == "Amount")
                {
                    AmountPaid = item.Value.ToString();
                }
            }

            Console.WriteLine($"This is the Amount Paid by the Customer:Ksh. {AmountPaid}");

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