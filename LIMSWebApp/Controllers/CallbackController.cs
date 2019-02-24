using System;
using System.Linq;
using LIMSCore.Billing;
using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSInfrastructure.Services.Messaging;
using LIMSWebApp.ViewModels.MpesaModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LIMSWebApp.Controllers
{

	[ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger<CallbackController> _log;       
        private readonly ISmsSender _smsSender;
		private readonly LIMSCoreDbContext _limsDbcontext;
		private readonly UserManager<ApplicationUser> _userManager;

		public CallbackController(
			ILogger<CallbackController> log,
			ISmsSender smsSender,
			LIMSCoreDbContext limscontext,
			UserManager<ApplicationUser> userManager)
        {
            _log = log;
          
            _smsSender = smsSender;
			_limsDbcontext = limscontext;
			_userManager = userManager;
        }

        [HttpPost]
		[Route("api/results")]
        public JToken Results([FromBody]JToken result)
        {
            //convert jtoken to String
            var stkresult = result.ToString();

			if (!stkresult.Contains("\"CallbackMetadata\""))
			{				
				_log.LogInformation($"Request Cancelled by user.{stkresult}");				
			}

            _log.LogWarning(LoggingEvents.UpdateItem, $"STK Callback: {stkresult}");

			var response = JsonConvert.DeserializeObject<STKResponse>(stkresult);

			var CheckoutID = response.Body.StkCallback.CheckoutRequestID;

			var MetaData = response.Body.StkCallback.CallbackMetadata.Item.ToList();

            var AmountPaid = "";
            var ReceiptNum = "";
            var DateOfTransaction = "";
            var PhoneNumber = "";

            //Handle CallbackMetadata
            foreach (var item in MetaData)
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
                CheckoutRequestID = CheckoutID,
                MerchantRequestId = response.Body.StkCallback.MerchantRequestID,
                ReceiptNumber = ReceiptNum,
                TransactionDate = DateTime.ParseExact(DateOfTransaction, "yyyyMMddHHmmss", null),
                PhoneNumber = PhoneNumber
            };

			var Checkout = _limsDbcontext.Checkout.FirstOrDefault(c => c.CheckoutRequest == CheckoutID);

			if(Checkout != null)
			{
				Checkout.AmountPaid = Convert.ToDouble(AmountPaid);

				_limsDbcontext.Checkout.Update(Checkout);

				_limsDbcontext.SaveChanges();

			}
			
			_limsDbcontext.Add(Payment);				
			
			_limsDbcontext.SaveChanges();

			_smsSender.SendSms("+254725589166", $"New Payment Made, Amount: {Payment.Amount}, Receipt No: {Payment.ReceiptNumber}, Phone No {Payment.PhoneNumber}");

            return result;             
        }



		[HttpPost]
		[Route("api/validate")]
		public JToken Validate([FromBody]JToken result)
		{
			_log.LogWarning($"Validation Request:{result}");

			return result.ToString();
		}

		[HttpPost]
		[Route("api/confirm")]
		public JToken Confirm([FromBody]JToken result)
		{			
			_log.LogWarning($"Confirmation Request:{result}");

			return result.ToString();
		}


	}
}
