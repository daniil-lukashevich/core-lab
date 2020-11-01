using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module_9.Extensions;
using Module_9.Middleware;

namespace Module_9
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(AuthorizeAttribute));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            /*Custom middleware*/
            /*Use*/
            var res = "";
            app.Use(async (context, next) =>
            {
                res += "Use¹1";
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                res += "Use¹2";
                await next.Invoke();
            });

            /*Map*/
            app.Map("/test", Test);

            /*MapWhen*/
            app.MapWhen(context =>
            {

                return context.Request.Query.ContainsKey("id") &&
                        context.Request.Query["id"] == "test";
            }, Test);

            app.UseMiddleware<UserAuthMiddleware>();
            app.UseUserAuth();

            /*Run*/
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from Run!");
            });
        }
        private static void Test(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Test");
            });
        }
    }
}
