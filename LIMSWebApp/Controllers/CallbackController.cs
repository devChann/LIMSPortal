using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMSCore.Billing;
using LIMSInfrastructure.Data;
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
        private readonly BillingDbContext _billing;

        public CallbackController(ILogger<CallbackController> log, BillingDbContext billing)
        {
            _log = log;
            _billing = billing;
        }

        [HttpPost]
        public JToken Post([FromBody]JToken result)
        {

            //convert jtoken to String
            var stkresult = result.ToString();

            //_log.LogInformation(stkresult);

            STKResponse response = JsonConvert.DeserializeObject<STKResponse>(stkresult);

            List<Item> MetaData = response.Body.StkCallback.CallbackMetadata.Item.ToList();

            string AmountPaid = "";
            string ReceiptNum = "";
            string DateOfTransaction = "";
            string PhoneNumber = "";

            //Handle CallbackMetadata
            foreach (Item item in MetaData)
            {
                if(item.Name == "Amount")
                {
                    AmountPaid = item.Value.ToString();
                }

                if(item.Name == "MpesaReceiptNumber")
                {
                    ReceiptNum = item.Value.ToString();
                }

                if(item.Name == "TransactionDate")
                {
                    DateOfTransaction = item.Value.ToString();
                }

                if(item.Name == "PhoneNumber")
                {
                    PhoneNumber = item.Value.ToString();
                }
            }

            var Payment = new MpesaTransaction
            {
                Id = new Guid(),
                Amount = AmountPaid,
                CheckoutRequestID = response.Body.StkCallback.CheckoutRequestID,
                MerchantRequestId = response.Body.StkCallback.MerchantRequestID,
                ReceiptNumber = ReceiptNum,
                TransactionDate = DateTime.ParseExact(DateOfTransaction, "yyyyMMddHHmmss", null),
                PhoneNumber = PhoneNumber
            };

            _billing.Add(Payment);
            
            _billing.SaveChanges();

            //logging stuff to stdout - to remove these after adding error handling and proper logging
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