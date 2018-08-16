﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSWebApp.ViewModels.MpesaModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MpesaLib.Interfaces;
using MpesaLib.Models;
using Stripe;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace LIMSWebApp.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly IAuthClient _auth;
        private readonly ILipaNaMpesaOnlineClient _lipaNaMpesa;       
        private readonly IConfiguration _config;
        private readonly BillingDbContext _payments;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly ISmsSender _smsSender;

        public PaymentsController(IAuthClient auth, ILipaNaMpesaOnlineClient lipaNampesa, 
            IConfiguration configuration, BillingDbContext payments, UserManager<ApplicationUser> userManager, ISmsSender smsSender)
        {
            _auth = auth;
            _lipaNaMpesa = lipaNampesa;            
            _config = configuration;
            _payments = payments;
            _userManger = userManager;
            _smsSender = smsSender;
        }

        //TO DO: implement payment method selection (card/mpesa)
        [HttpGet]
        [Route("/payment-method")]
        public IActionResult Index()
        {         
            return View();
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
        //[Authorize(Roles ="Administrator")]
        public IActionResult PaymentsList()
        {
            var paymentsmade = _payments.MpesaTransaction.ToList();

            List<PaymentsListViewModel> paymentList = new List<PaymentsListViewModel>();

            if(paymentsmade != null)
            {                
                
                paymentList = paymentsmade.Select(a => new PaymentsListViewModel
                {
                    Amount = a.Amount,
                    ReceiptNumber =a.ReceiptNumber,
                    CheckOutID = a.CheckoutRequestID,
                    CustomerName = a.PhoneNumber ,//?? HttpContext.User?.Identity.Name, TO DO: Get customer name from parcels db
                    PaymentDate = a.TransactionDate,
                    PhoneNumber = a.PhoneNumber

                }).ToList();
                
            }          
            
            return View(paymentList);
        }

        [HttpGet]
        [Route("/make-payment")]
        public IActionResult PayWithMpesa()
        {
            return View("MpesaExpress");
        }

        [HttpPost]
        [Route("/make-payment")]
        public async Task<IActionResult> PayWithMpesa(MpesaExpressViewModel Payment)
        {
            var consumerKey = _config["MpesaConfiguration:ConsumerKey"];

            var consumerSecret = _config["MpesaConfiguration:ConsumerSecret"];

            var accesstoken = await _auth.GetToken(consumerKey, consumerSecret);

            var MpesaExpressObject = new LipaNaMpesaOnline
            {
                AccountReference = "ref",
                Amount = Payment.Amount,
                PartyA = Payment.PhoneNumber,
                PartyB = "174379",
                BusinessShortCode = "174379",
                CallBackURL = "https://demo.osl.co.ke:7575/lims/api/callback",
                Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTgwNzE2MTI0OTE2",
                //Password = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(PartyB + Passkey + Timestamp)),    
                PhoneNumber = Payment.PhoneNumber, //254708374149
                Timestamp = "20180716124916",//DateTime.Now.ToString("yyyyMMddHHmmss"),
                TransactionDesc = "test"
                //TransactionType = "CustomerPayBillOnline"
            };

            var paymentrequest = await _lipaNaMpesa.MakePayment(MpesaExpressObject, accesstoken);

            _smsSender.SendSms("+254725589166", $"New Payment Request has been made.");


            ViewData["Payment"] = paymentrequest;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
