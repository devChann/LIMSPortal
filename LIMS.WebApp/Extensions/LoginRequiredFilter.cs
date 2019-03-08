using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.Extensions
{
    public class LoginRequiredFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!AttributeManager.HasAttribute(context, typeof(LogInRequired))) return;

            if (context.HttpContext.User.Identity.IsAuthenticated) return;

            context.Result = new RedirectResult("/Identity/Account/Login?ReturnUrl=" + Uri.EscapeDataString(context.HttpContext.Request.Path));
        }

      
    }
}
