using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquidSite.Data.Database;
using SquidSite.Database.Interfaces;

namespace SquidSite
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SquidSiteDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AWS Connection")));
            services.AddTransient(typeof(IBlogDAL), typeof(BlogDBContext));
            services.AddMvc();
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
                    defaults: new { controller = "Blog", action = "AllBlogs" }
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

                routes.MapRoute(
                    name: "catch",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "Index" }
                    );
            });

        }
    }
}
