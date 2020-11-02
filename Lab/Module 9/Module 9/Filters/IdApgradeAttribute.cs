using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_9.Filters
{
    public class IdApgradeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (string.IsNullOrEmpty(context.RouteData.Values["id"]?.ToString()))
            {
                context.ActionArguments["id"] = "__default";
            }
            await next();
        }
    }
}
