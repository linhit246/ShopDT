using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTN.Helpers;
using DoAnTN.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoAnTN
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

            services.AddScoped<IpaginationService, paginationService>();

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddSession(options => {
                options.Cookie.Name = "cart";
                options.IdleTimeout = TimeSpan.FromSeconds(20000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<ShopDienThoaiContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ConnectDB")));
            var connection = @"Data Source=MyPC;Initial Catalog=ShopDienThoai;Integrated Security=True";
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
                app.UseExceptionHandler("/Error/500");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=IndexClient}/{id?}");
            });


        }
    }
}
