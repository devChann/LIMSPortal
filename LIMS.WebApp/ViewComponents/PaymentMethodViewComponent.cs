using LIMS.Infrastructure.Services.Payment;
using LIMS.WebApp.ViewModels.PaymentViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.ViewComponents
{
	public class PaymentMethodViewComponent: ViewComponent
	{
		private readonly IBraintreeService _braintreeService;

		public PaymentMethodViewComponent(IBraintreeService braintreeService)
		{
			_braintreeService = braintreeService;
		}


		public async Task<IViewComponentResult> InvokeAsync(string amount, string invoicenumber)
        {
			var gateway = _braintreeService.GetGateway();

			var clientToken = gateway.ClientToken.Generate();

			ViewBag.ClientToken = clientToken;

			var checkoutviewModel = new CheckoutViewModel
			{
				Amount = amount,
				InvoiceNumber = invoicenumber
			};
			
			return View(checkoutviewModel);
        }

	}
}
