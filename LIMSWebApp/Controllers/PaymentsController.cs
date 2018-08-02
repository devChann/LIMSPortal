using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMSWebApp.ViewModels.MpesaModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MpesaLib.Clients;
using MpesaLib.Models;
using Stripe;

namespace LIMSWebApp.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly AuthClient _auth;
        private LipaNaMpesaOnlineClient _lipaNaMpesa;
        private C2BRegisterUrlClient _c2bregister;
        private readonly C2BClient _c2bSimulate;
        private readonly IConfiguration _config;

        public PaymentsController(AuthClient auth, LipaNaMpesaOnlineClient lipaNampesa, C2BRegisterUrlClient c2bregister,
           C2BClient c2bsim, IConfiguration configuration)
        {
            _auth = auth;
            _lipaNaMpesa = lipaNampesa;
            _c2bregister = c2bregister;
            _c2bSimulate = c2bsim;
            _config = configuration;
        }
        

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {          

            var consumerKey = _config["MpesaConfiguration:ConsumerKey"];

            var consumerSecret = _config["MpesaConfiguration:ConsumerSecret"];

            var accesstoken = await _auth.GetToken(consumerKey,consumerSecret);

            var paymentitems = new MpesaItems();

            var paymentdata = await _lipaNaMpesa.MakePayment(paymentitems.lipaonline, accesstoken);

            var c2bregister = await _c2bregister.RegisterUrl(paymentitems.c2bregisterUrl, accesstoken);

            var c2bsimulator = await _c2bSimulate.MakeC2BPayment(paymentitems.c2b, accesstoken);

            ViewData["Payment"] = paymentdata;
            ViewData["C2bRegister"] = c2bregister;
            ViewData["C2bSimulate"] = c2bsimulator;

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

        public IActionResult Error()
        {
            return View();
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

            ViewData["Payment"] = paymentrequest;

            return View();
        }
    }
}
