using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMS.WebApp.Controllers;
using LIMS.WebApp.Areas.Identity.Pages.Account;

namespace Microsoft.AspNetCore.Mvc
{
	public static class UrlHelperExtensions
	{
		//These urlhelpers have not been reconfigured for pageModels
		public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
		{
			return urlHelper.Action(
				action: nameof(ConfirmEmailModel),
				controller: "Account",
				values: new { userId, code },
				protocol: scheme);
		}

		public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
		{
			return urlHelper.Action(
				action: nameof(ResetPasswordModel),
				controller: "Account",
				values: new { userId, code },
				protocol: scheme);
		}
	}
}
