using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMSWebApp.ViewModels.MpesaModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MpesaLib.Clients;
using Stripe;

namespace LIMSWebApp.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly AuthClient _auth;
        private LipaNaMpesaOnlineClient _lipaNaMpesa;
        private readonly IConfiguration _config;

        public PaymentsController(AuthClient auth, LipaNaMpesaOnlineClient lipaNampesa, IConfiguration configuration)
        {
            _auth = auth;
            _lipaNaMpesa = lipaNampesa;
            _config = configuration;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var consumerKey = _config["MpesaConfiguration:ConsumerKey"];

            var consumerSecret = _config["MpesaConfiguration:ConsumerSecret"];

            var accesstoken = "eFmCUwG2IkfbLDLGf1BK4DPZ3Oqp";// await _auth.GetData(consumerKey,consumerSecret);

            var paymentitems = new LipaNaMpesaItem();

            var paymentdata = await _lipaNaMpesa.MakePayment(paymentitems.lipaonline, accesstoken);

            ViewData["Timestamp"] = paymentitems.lipaonline.Timestamp;

            ViewData["Payment"] = paymentdata;

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

        public IActionResult PayWithMpesa()
        {
            return View();
        }
    }
}
