using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.Areas.Identity
{
    public class AuthorizationPolicy
    {
        internal static void Execute(AuthorizationOptions options)
        {

            options.AddPolicy("CanDeleteStuff", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole("Administrator");
            });

            // Logged in users can write comments
            // Authors can write articles
            // Authors can edit their own articles
            // Editors can edit anyones articles
            // Administrators can delete articles


        }
    }
}
