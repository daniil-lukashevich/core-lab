using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_9.Middleware
{
    public class UserAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public UserAuthMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var auth = context.Request.Cookies["Auth"];
            if (auth != "good")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized user!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
