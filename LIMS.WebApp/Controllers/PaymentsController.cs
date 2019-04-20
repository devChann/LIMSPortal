using LIMS.Infrastructure.Data;
using LIMS.Infrastructure.Identity;
using LIMS.Infrastructure.Services;
using LIMS.WebApp.ViewModels.MpesaModels;
using LIMS.WebApp.ViewModels.PropertiesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
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
using Braintree;
using Microsoft.AspNetCore.Http;
using LIMS.Infrastructure.Services.Payment;
using System.IO;
using Newtonsoft.Json;
using LIMS.Infrastructure.Services.Payment.Mpesa;
using LIMS.Core.Billing;
using LIMS.Infrastructure.Services.Messaging;

namespace LIMS.WebApp.Controllers
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
		private readonly IHostEnvironment _hostingEnvironment;
		private readonly IBraintreeService _braintreeService;

		public PaymentsController(IMpesaClient mpesaClient,IConfiguration configuration, LIMSCoreDbContext payments,
			UserManager<ApplicationUser> userManager, ISmsSender smsSender, ILogger<PaymentsController> logger,
			LIMSCoreDbContext limscontext, IHostEnvironment hostingEnvironment, IBraintreeService braintreeService)
        {
			_mpesaClient = mpesaClient;
			_config = configuration;
            _payments = payments;
            _userManger = userManager;
            _smsSender = smsSender;
			_logger = logger;
			_limsDbcontext = limscontext;
			_hostingEnvironment = hostingEnvironment;
			_braintreeService = braintreeService;
		}

		private string ConsumerKey => _config["MpesaConfiguration:ConsumerKey"];

		private string ConsumerSecret => _config["MpesaConfiguration:ConsumerSecret"];

		private string AccessToken => _mpesaClient.GetAuthToken(ConsumerKey, ConsumerSecret, "oauth/v1/generate?grant_type=client_credentials");

		private string PassKey => _config["MpesaConfiguration:PassKey"];

		private string MpesaCertificate => Path.Combine(_hostingEnvironment.ContentRootPath, "Certificates", "prod.cer");

		private string InitiatorPassword => _config["MpesaConfiguration:InitiatorPassword"];		

		private string SecurityCredential => Credentials.EncryptPassword(MpesaCertificate, InitiatorPassword);

		private string C2BPayBillNumber => _config["MpesaConfiguration:BusinessShortCodeC2B"];
		private string LNMOPayBillNumber => _config["MpesaConfiguration:BusinessShortCodeLNMO"];



		//TO DO: implement payment method selection (card/mpesa)
		[HttpGet]
        [Route("/payment-method")]
        public IActionResult Index()
        {         
            return View();
        }

        [HttpGet]
        public IActionResult Checkout(string property, string invoicenumber)
        {
			var parcel = _limsDbcontext.Parcel
				.Include(i => i.Rate)				
				.Include(p => p.Invoices)				
				.Include(i => i.Owner)
				.Where(a => a.ParcelNum == property).SingleOrDefault();

			var Invoices = parcel.Invoices.ToList();

			var filteredInvoice = Invoices.FirstOrDefault(a => a.InvoiceNumber == invoicenumber);

			var ratesmodel = new RateViewModel {

				ParcelNumber = property,
				PendingRate = filteredInvoice.InvoiceAmount.ToString(),
				OwnerName = parcel.Owner.Name,
				FinancialYear = DateTime.Now.AddYears(-1).Year + "/" + DateTime.Now.Year,				
				OwnerPIN = parcel.Owner.PIN,
				InvoiceID = filteredInvoice.InvoiceId,
				InvoiceNumber = filteredInvoice.InvoiceNumber

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

        

        [HttpPost]
		[Route("/make-payment")]
		public async Task<IActionResult> PayWithMpesa(IFormCollection collection)
        {		
			var MpesaExpressObject2 = new LipaNaMpesaOnlineDto
			{
				AccountReference = collection["phone_number"],
				Amount = collection["amount"],
				PartyA = collection["phone_number"],
				PartyB = LNMOPayBillNumber,
				BusinessShortCode = LNMOPayBillNumber,
				CallBackURL = _config["MpesaConfiguration:LNMOCallbackURL"],
				Passkey = PassKey,				  
				PhoneNumber = collection["phone_number"], 				
				TransactionDesc = "Land Rate Payment",
				TransactionType = TransactType.CustomerPayBillOnline
			};

			var paymentrequest = "";

			try
			{
				paymentrequest = await _mpesaClient.MakeLipaNaMpesaOnlinePaymentAsync(MpesaExpressObject2, AccessToken, RequestEndPoint.LipaNaMpesaOnline);
			}
			catch (Exception e)
			{
				_logger.LogError($"An Error Occured while Making LipaNaMpesa payment request:{e.Message}");
			}	

			_logger.LogWarning(LoggingEvents.GetItem, $"Mpesa LNMO Response: {paymentrequest}");

			return RedirectToAction("ShowMpesaResult", new { response = paymentrequest, customerNumber = collection["phone_number"], invoicenumber = collection["invoice_number"] });

			
        }

		[HttpPost("/mpesatransactionstatus")]
		public async Task<IActionResult> MpesaOnlineTransactionStatus(IFormCollection formcollection)
		{

			var accesstoken = await _mpesaClient.GetAuthTokenAsync(ConsumerKey, ConsumerSecret, RequestEndPoint.AuthToken);

			var LNMOQuery = new LipaNaMpesaQueryDto
			{
				BusinessShortCode = "174379",
				CheckoutRequestID = formcollection["checkoutRequestId"],
				Passkey = PassKey
			};

			var queryResult = await _mpesaClient.QueryLipaNaMpesaTransactionAsync(LNMOQuery, accesstoken, RequestEndPoint.QueryLipaNaMpesaOnlieTransaction);



			return RedirectToAction("ConfirmMpesaPayment", new { response = queryResult, customerNumber = formcollection["phone_number"] });

		}


		[HttpGet("/showmpesaresult")]
		public IActionResult ShowMpesaResult(string response, string customerNumber, string invoicenumber)
		{
			if(response == null)
			{
				return RedirectToAction("Error","Home", new { statusCode = 500});
			}

			//deserialize response and query transaction stastus
			var res = JsonConvert.DeserializeObject<MpesaStkResponse>(response);

			//handle edge cases and errors

			//Get invoice and add a checkout			
			var invoice = _limsDbcontext.Invoice
				.Include(i => i.Payments)
				.FirstOrDefault(i => i.InvoiceNumber == invoicenumber);

			var InvoiceCheckout = new Checkout {
				CheckoutId = Guid.NewGuid(),
				CheckoutDate = DateTime.Now,
				CheckoutRequestId = res.CheckoutRequestID,				
			};

			var checkout = _limsDbcontext.Checkout.FirstOrDefaultAsync(i => i.CheckoutId == InvoiceCheckout.CheckoutId);

			

			if(invoice != null )
			{
				if (_limsDbcontext.Checkout.Any(a => a.CheckoutId != InvoiceCheckout.CheckoutId))
				{
					_limsDbcontext.Checkout.Add(InvoiceCheckout);
				}
					
				_limsDbcontext.SaveChanges();
			}
			

			//pass data to view/page via viewbag
			ViewBag.ResponseCode = res.ResponseCode;
			ViewBag.CheckoutRequestId = res.CheckoutRequestID;
			ViewBag.MerchantRequestId = res.MerchantRequestID;
			ViewBag.CustomerMessage = res.CustomerMessage;
			ViewBag.ResponseDescription = res.ResponseDescription;
			ViewBag.CustomerNumber = customerNumber;

			return View();
		}

		[HttpGet("/mpesaconfirmation")]
		public IActionResult ConfirmMpesaPayment(string response, string customerNumber)
		{
			////deserialize response and query transaction stastus
			var res = JsonConvert.DeserializeObject<LNMOQueryResponse>(response);

			//handle edge cases and errors  

			//pass data to view/page via viewbag
			ViewBag.ResultDescription = res.ResultDesc;
			ViewBag.ResultCode = res.ResultCode;
			ViewBag.ResponseDescription = res.ResponseDescription;
			ViewBag.CustomerNumber = customerNumber;

			return View();
		}


		public IActionResult Error()
        {
            return View();
        }



		public static readonly TransactionStatus[] transactionSuccessStatuses =
		{
			TransactionStatus.AUTHORIZED,
			TransactionStatus.AUTHORIZING,
			TransactionStatus.SETTLED,
			TransactionStatus.SETTLING,
			TransactionStatus.SETTLEMENT_CONFIRMED,
			TransactionStatus.SETTLEMENT_PENDING,
			TransactionStatus.SUBMITTED_FOR_SETTLEMENT
		};

		[HttpPost]
		[Route("/braintreecheckout")]
		public IActionResult BrainTreeCheckout(IFormCollection collection)
		{
			string nonceFromTheClient = collection["payment_method_nonce"];
			var amount = decimal.Parse(collection["amount"]);


			var request = new TransactionRequest
			{
				Amount = amount, //10.00M,				
				PaymentMethodNonce = nonceFromTheClient,
				Options = new TransactionOptionsRequest
				{
					SubmitForSettlement = true					
				},
				MerchantAccountId = "limsportaltests"
			};

			var gateway = _braintreeService.GetGateway();

			var result = gateway.Transaction.Sale(request);

			if (result.IsSuccess())
			{
				var transaction = result.Target;
				return RedirectToAction("Show", new { id = transaction.Id });
			}
			else if (result.Transaction != null)
			{
				return RedirectToAction("Show", new { id = result.Transaction.Id });
			}
			else
			{
				var errorMessages = "";
				foreach (var error in result.Errors.DeepAll())
				{
					errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
				}
				TempData["Flash"] = errorMessages;
				return RedirectToAction("New");
			}
		}

		public ActionResult New()
		{
			var gateway = _braintreeService.GetGateway();
			var clientToken = gateway.ClientToken.Generate();
			ViewBag.ClientToken = clientToken;
			return View();
		}

		public ActionResult Show(string id)
		{
			var gateway = _braintreeService.GetGateway();
			var transaction = gateway.Transaction.Find(id);

			if (transactionSuccessStatuses.Contains(transaction.Status))
			{
				TempData["header"] = "Sweet Success!";
				TempData["icon"] = "success";
				TempData["message"] = "Your test transaction has been successfully processed. See the Braintree API response and try again.";
			}
			else
			{
				TempData["header"] = "Transaction Failed";
				TempData["icon"] = "fail";
				TempData["message"] = "Your test transaction has a status of " + transaction.Status + ". See the Braintree API response and try again.";
			};

			ViewBag.Transaction = transaction;
			return View();
		}

	}

	public static class ResponseType
	{
		public static string Completed { get { return "Completed"; } }
		public static string Cancelled { get { return "Cancelled"; } }
	}
}
