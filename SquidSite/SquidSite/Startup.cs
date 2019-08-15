using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SquidSite.Data.Database;
using SquidSite.Database.Interfaces;

namespace SquidSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient(typeof(IBlogDAL), typeof(MockBlogDB));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "",
                    defaults: new { controller = "Home", action = "Index" }
                    );

                routes.MapRoute(
                    name: "Blog",
                    template: "/Blog",
                    defaults: new { controller = "Home", action = "Blog" }
                    );

                routes.MapRoute(
                    name: "Shop",
                    template: "/Shop",
                    defaults: new { controller = "Shop", action = "Index" }
                    );

                routes.MapRoute(
                    name: "ItemInfoPage",
                    template: "/Shop/ItemInfoPage",
                    defaults: new { controller = "Shop", action = "ItemInfoPage" }
                    );

                routes.MapRoute(
                    name: "register",
                    template: "/Register",
                    defaults: new { controller = "User", action = "Register" }
                    );

                routes.MapRoute(
                    name: "login",
                    template: "/Login",
                    defaults: new { controller = "User", action = "Login" }
                    );
            });

        }
    }
}
