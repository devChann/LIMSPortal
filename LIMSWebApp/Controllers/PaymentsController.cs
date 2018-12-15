﻿using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSWebApp.ViewModels.MpesaModels;
using LIMSWebApp.ViewModels.PropertiesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MpesaLib.Helpers;
using MpesaLib;
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
        private readonly LIMSCoreDbContext _payments;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly ISmsSender _smsSender;
		private readonly ILogger _logger;
		private readonly LIMSCoreDbContext _limsDbcontext;
		private readonly IMpesaClient _mpesaClient;
		private readonly IHostingEnvironment _hostingEnvironment;

		public PaymentsController(IMpesaClient mpesaClient,IConfiguration configuration, LIMSCoreDbContext payments,
			UserManager<ApplicationUser> userManager, ISmsSender smsSender, ILogger<PaymentsController> logger,
			LIMSCoreDbContext limscontext, IHostingEnvironment hostingEnvironment)
        {
			_mpesaClient = mpesaClient;
			_config = configuration;
            _payments = payments;
            _userManger = userManager;
            _smsSender = smsSender;
			_logger = logger;
			_limsDbcontext = limscontext;
			_hostingEnvironment = hostingEnvironment;
			
			
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
        [Authorize(Roles = "Administrator")]
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
		[Route("/make-payment")]
		public async Task<IActionResult> PayWithMpesa(RateViewModel Payment)
        {
            var consumerKey = _config["MpesaConfiguration:ConsumerKey"];

            var consumerSecret = _config["MpesaConfiguration:ConsumerSecret"];

			var passKey = _config["MpesaConfiguration:PassKey"];

            var accesstoken = await _mpesaClient.GetAuthTokenAsync(consumerKey, consumerSecret, "oauth/v1/generate?grant_type=client_credentials");


			//var certificate =  _hostingEnvironment.ContentRootPath + "\\Certificates\\prod.cer";
			var certificate = @"C:\Certificates\prod.cer";

			var securityCredential = Credentials.EncryptPassword(certificate, "971796"); //for B2B, B2C, Reversal, TransactionStatus APIs

			var registerMpesaUrl = new CustomerToBusinessRegisterUrlDto
			{
				ConfirmationURL = "https://demo.osl.co.ke:7574/api/confirm",
				ValidationURL = "https://demo.osl.co.ke:7574/api/validate",
				ResponseType = "Cancelled",
				ShortCode = "603047"
			};

			try
			{
				var registerUrl = await _mpesaClient.RegisterC2BUrlAsync(registerMpesaUrl, accesstoken, "mpesa/c2b/v1/registerurl");

				_logger.LogWarning(LoggingEvents.GetItem, $"Register Url Result:{registerUrl}");
			}
			catch (Exception e)
			{

				_logger.LogError($"An Error Occured:{e.Message}");
			}

			

			

			var MpesaExpressObject2 = new LipaNaMpesaOnlineDto
			{
				AccountReference = "ref",
				Amount = Payment.PendingRate,
				PartyA = Payment.PhoneNumber,
				PartyB = "174379",
				BusinessShortCode = "174379",
				CallBackURL = "https://demo.osl.co.ke:7574/api/results",
				Passkey = passKey,				  
				PhoneNumber = Payment.PhoneNumber, 				
				TransactionDesc = "test"					
			};

			var paymentrequest = await _mpesaClient.MakeLipaNaMpesaOnlinePaymentAsync(MpesaExpressObject2, accesstoken, "mpesa/stkpush/v1/processrequest");
			
            await _smsSender.SendSmsAsync($"+{Payment.PhoneNumber}", $"Please enter Mpesa PIN on your phone to complete payment of Ksh: {Payment.PendingRate}");

			//await _smsSender.SendSmsAsync($"+{Payment.PhoneNumber}", $"Security Credential: {securityCredential}");

			//await _smsSender.SendSmsAsync("+254713928142", "Chann, you need to look into this billing thing for LIMS!!");

			_logger.LogWarning(LoggingEvents.GetItem, $"Mpesa LNMO Response: {paymentrequest}");
			

			return Redirect("/my-properties");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
