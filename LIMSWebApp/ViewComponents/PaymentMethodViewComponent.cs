using LIMSInfrastructure.Services.Payment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewComponents
{
	public class PaymentMethodViewComponent: ViewComponent
	{
		private readonly IBraintreeService _braintreeService;

		public PaymentMethodViewComponent(IBraintreeService braintreeService)
		{
			_braintreeService = braintreeService;
		}


		public async Task<IViewComponentResult> InvokeAsync()
        {
			var gateway = _braintreeService.GetGateway();

			var clientToken = gateway.ClientToken.Generate();

			ViewBag.ClientToken = clientToken;
			
			return View();
        }

	}
}
