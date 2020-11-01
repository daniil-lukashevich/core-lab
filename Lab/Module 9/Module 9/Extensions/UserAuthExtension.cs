using Microsoft.AspNetCore.Builder;
using Module_9.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_9.Extensions
{
    public static class UserAuthExtension
    {
        public static IApplicationBuilder UseUserAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAuthMiddleware>();
        }
    }
}
