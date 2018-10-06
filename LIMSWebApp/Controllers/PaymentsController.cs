using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSWebApp.ViewModels.MpesaModels;
using LIMSWebApp.ViewModels.PropertiesViewModesl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MpesaLib.Interfaces;
using MpesaLib.Models;
using MpesaLib.Helpers;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LIMSWebApp.Controllers
{
	[Authorize]
    public class PaymentsController : Controller
    {          
        private readonly IConfiguration _config;
        private readonly BillingDbContext _payments;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly ISmsSender _smsSender;
		private readonly LIMSCoreDbContext _limsDbcontext;
		private readonly IMpesaClient _mpesaClient;

		public PaymentsController(IMpesaClient mpesaClient,IConfiguration configuration, BillingDbContext payments,
			UserManager<ApplicationUser> userManager, ISmsSender smsSender, LIMSCoreDbContext limscontext)
        {
			_mpesaClient = mpesaClient;
			_config = configuration;
            _payments = payments;
            _userManger = userManager;
            _smsSender = smsSender;
			_limsDbcontext = limscontext;
			
			
        }

        //TO DO: implement payment method selection (card/mpesa)
        [HttpGet]
        [Route("/payment-method")]
        public IActionResult Index()
        {         
            return View();
        }

        [HttpGet]
        public IActionResult Checkout(string property)
        {
			var parcel = _limsDbcontext.Parcel
				.Include(i => i.Rate)				
				.Include(p => p.Payments)				
				.Include(i => i.Owner)
				.Where(a => a.ParcelNum == property).SingleOrDefault();

			var pendingRate = parcel.Rate.Amount.ToString();

			var ratesmodel = new RateViewModel {

				ParcelNumber = property,
				PendingRate = pendingRate,
				OwnerName = parcel.Owner.Name,
				FinancialYear = DateTime.Now.AddYears(-1).Year + "/" + DateTime.Now.Year,
				//OwnerId = parcel.Owner.Id.ToString(),
				OwnerPIN = parcel.Owner.PIN              

            };

            return View(ratesmodel);
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> PaymentsList(int? page)
        {
            var paymentsmade = await _payments.MpesaTransaction.ToListAsync();          

            var paymentList = new List<PaymentsListViewModel>();

            var pageNumber = page ?? 1;

            if (paymentsmade != null)
            {

                paymentList = paymentsmade.Select(a => new PaymentsListViewModel
                {
                    Amount = a.Amount,
                    ReceiptNumber = a.ReceiptNumber,
                    CheckOutID = a.CheckoutRequestID,
                    CustomerName = a.PhoneNumber,//?? HttpContext.User?.Identity.Name, TO DO: Get customer name from parcels db
                    PaymentDate = a.TransactionDate,
                    PhoneNumber = a.PhoneNumber

                }).ToList();

            }

            //var queryablePayments = paymentList.AsQueryable(); //convert list to IQueryable

            //var pageOfPayments = queryablePayments.ToPagedList(pageNumber, 10); //create pagelist

            return View(paymentList);
        }

        [HttpGet]
        [Route("/make-payment")]
        public IActionResult PayWithMpesa(string apiresult)
        {
			//var owner = _limsDbcontext.Owner
			//	.Where(o => o.TelephoneAddress == "254725589166").Single();

			////get property
			//var parcel = _limsDbcontext.Parcel
			//	.Include(r => r.Rate).Where(o => o.OwnerId == owner.Id).FirstOrDefault();

			//var currentRate = parcel.Rate.Amount;

			////deduct payment made from rates database
			//var ratepaid = 15;

			//var balance = currentRate -ratepaid;

			//currentRate = balance;

			//parcel.Rate.Amount = currentRate;

			//_limsDbcontext.SaveChanges();

			//ViewData["Balance"] = currentRate;
			//ViewData["Name"] = owner.Name;
			ViewData["Result"] = apiresult;

			return View();
        }

        [HttpPost]       
        public async Task<IActionResult> MpesaPay(RateViewModel Payment)
        {

            var consumerKey = _config["MpesaConfiguration:ConsumerKey"];

            var consumerSecret = _config["MpesaConfiguration:ConsumerSecret"];

			var passKey = _config["MpesaConfiguration:PassKey"];

            var accesstoken = await _mpesaClient.GetAuthTokenAsync(consumerKey, consumerSecret, "oauth/v1/generate?grant_type=client_credentials");


			var certificate = @"C:\Dev\Work\MpesaIntegration\MpesaLibSamples\WebApplication1\WebApplication1\Certificate\prod.cer";

			var securityCredential = Credentials.EncryptPassword(certificate, "971796");

            //var MpesaExpressObject = new LipaNaMpesaOnline
            //{
            //    AccountReference = "ref",
            //    Amount = Payment.PendingRate,
            //    PartyA = Payment.PhoneNumber,
            //    PartyB = "174379",
            //    BusinessShortCode = "174379",
            //    CallBackURL = "https://demo.osl.co.ke:7575/lims/api/callback",
            //    Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTgwNzE2MTI0OTE2",
            //    //Password = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(PartyB + Passkey + Timestamp)),    
            //    PhoneNumber = Payment.PhoneNumber, //254708374149
            //    Timestamp = "20180716124916",//DateTime.Now.ToString("yyyyMMddHHmmss"),
            //    TransactionDesc = "test"
            //    //TransactionType = "CustomerPayBillOnline"
            //};

			var MpesaExpressObject2 = new LipaNaMpesaOnline
			{
				AccountReference = "ref",
				Amount = Payment.PendingRate,
				PartyA = Payment.PhoneNumber,
				PartyB = "174379",
				BusinessShortCode = "174379",
				CallBackURL = "https://demo.osl.co.ke:7575/lims/api/callback",
				Passkey = passKey,				  
				PhoneNumber = Payment.PhoneNumber, 				
				TransactionDesc = "test"					
			};

			var paymentrequest = await _mpesaClient.MakeLipaNaMpesaOnlinePaymentAsync(MpesaExpressObject2, accesstoken, "mpesa/stkpush/v1/processrequest");
			
            await _smsSender.SendSmsAsync($"+{Payment.PhoneNumber}", $"Please Enter your Mpesa password on your phone to Complete Your Pending land rate payment of Ksh: {Payment.PendingRate}");

			//await _smsSender.SendSmsAsync($"+{Payment.PhoneNumber}", $"Security Credential: {securityCredential}");

			//await _smsSender.SendSmsAsync("+254713928142", "Chann, you need to look into this billing thing for LIMS!!");


			ViewData["Payment"] = paymentrequest;

			var apiresult = ViewData["Payment"].ToString();

			return Redirect("~/my-properties");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
