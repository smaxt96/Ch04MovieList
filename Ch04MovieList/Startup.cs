using Ch04MovieList.Models;
using Ch04MovieList.Models.Olympics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Ch04MovieList
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
            services.AddControllersWithViews();
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            services.AddDbContext<ContactContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            services.AddDbContext<CountryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
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
                endpoints.MapAreaControllerRoute(
                  name: "admin",
                  areaName: "Admin",
                  pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                 name: "module1",
                 areaName: "Module1",
                 pattern: "Module1/{controller=Birthday}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                 name: "module2",
                 areaName: "Module2",
                 pattern: "Module2/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "module5",
                  areaName: "Module5",
                  pattern: "Module5/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                 name: "module5",
                 areaName: "Module5",
                 pattern: "Module5/{controller=DummyRule}/{action=Index}/{name}/Module{num}");

                endpoints.MapAreaControllerRoute(
                name: "module6",
                areaName: "Module6",
                pattern: "Module6/{controller=Student}/{action=Index}/{accessLevel}");

                endpoints.MapAreaControllerRoute(
               name: "module7",
               areaName: "Module7",
               pattern: "Module7/{controller}/{action}/cat/{activeCat=all}/game/{activeGame=all}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
