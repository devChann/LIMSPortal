using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIMS.WebApp.Areas.Identity.Pages.Account
{
    public class ConfirmEmailSentModel : PageModel
    {
		[BindProperty]
		public string Email { get; set; }

		public void OnGet(string UserEmail)
        {
			Email = UserEmail;
        }
    }
}
