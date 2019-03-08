﻿using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace LIMS.WebApp.Extensions
{
    public class AttributeManager
    {
        public static Boolean HasAttribute(AuthorizationFilterContext context, Type targetAttribute)
        {
            var hasAttribute = false;
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                hasAttribute = controllerActionDescriptor
                                                .MethodInfo
                                                .GetCustomAttributes(targetAttribute, false).Any();
            }

            return hasAttribute;
        }

    }
}
