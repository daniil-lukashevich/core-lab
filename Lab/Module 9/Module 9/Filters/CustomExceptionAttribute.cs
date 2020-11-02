using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_9.Filters
{
    public class CustomExceptionAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new { 
                action = context.ActionDescriptor.DisplayName,
                exceptionMessage = context.Exception.Message,
            });
            context.ExceptionHandled = true;
        }
    }
}
