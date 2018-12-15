using System;
using System.Linq;
using LIMSCore.Billing;
using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSWebApp.ViewModels.MpesaModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LIMSWebApp.Controllers
{
	//[Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger<CallbackController> _log;
        private readonly LIMSCoreDbContext _billing;
        private readonly ISmsSender _smsSender;
		private readonly LIMSCoreDbContext _limsDbcontext;
		private readonly UserManager<ApplicationUser> _userManager;

		public CallbackController(ILogger<CallbackController> log, LIMSCoreDbContext billing,
			ISmsSender smsSender, LIMSCoreDbContext limscontext, UserManager<ApplicationUser> userManager)
        {
            _log = log;
            _billing = billing;
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
				Console.WriteLine("Request Cancelled by user");
			}

            _log.LogWarning(LoggingEvents.UpdateItem, $"STK Callback: {stkresult}");

			var response = JsonConvert.DeserializeObject<STKResponse>(stkresult);
			
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
                CheckoutRequestID = response.Body.StkCallback.CheckoutRequestID,
                MerchantRequestId = response.Body.StkCallback.MerchantRequestID,
                ReceiptNumber = ReceiptNum,
                TransactionDate = DateTime.ParseExact(DateOfTransaction, "yyyyMMddHHmmss", null),
                PhoneNumber = PhoneNumber
            };

            _billing.Add(Payment);
			_billing.SaveChanges();

			//get owner from database
			var owner = _limsDbcontext.Owner
				.Where(o => o.TelephoneAddress == PhoneNumber).Single();

			//get property
			var parcel = _limsDbcontext.Parcel
				.Include(r => r.Rate).Where(o => o.OwnerId == owner.Id).FirstOrDefault();

			var currentRate = parcel.Rate.Amount;

			//deduct payment made from rates database
			var ratepaid = AmountPaid;

			var balance = currentRate - int.Parse(ratepaid);

			currentRate = balance;

			parcel.Rate.Amount = currentRate;			
			
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
