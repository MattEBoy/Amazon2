
using Amazon.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Amazon
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
            services.AddDbContext<BookDBContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlite(Configuration["ConnectionSTrings:AmazonConnection"]);
            });
            services.AddControllersWithViews();

            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();
            //URLs have been improved to use /P2, /P3, /P4 etc. to access a specific page
            //I decided to go with books/{page} 
            //but if it were to need to be identical to /P2 /P3 the code would be 
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        "pagination",
            //        "books/P{page}",
            //        new { Controller = "Home", action = "Index" });
            //    endpoints.MapDefaultControllerRoute();
            //});
            app.UseEndpoints(endpoints =>
            {
                //As in the example, modify the Endpoints so that the user can add something like "/Books/Autobiography" onto the URL and get results. (NOTE: Does not need to follow that specific path.) (see below)
                endpoints.MapControllerRoute(
                    "categpage",
                    "category/{category}/books/{pageNumber:int}",
                     new { Controller = "Home", action = "Index" });
                //The app has the built -in functionality to filter by adding an argument to the controller(i.e. "/?category=autobiography) for the category (see below)
                endpoints.MapControllerRoute(
                    "categ",
                    "category/{category}",
                     new { Controller = "Home", action = "Index", pageNumber = 1});

                endpoints.MapControllerRoute(
                    "pagination",
                    "books/{pageNumber}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });


            SeedData.EnsureaPopulated(app);
        }
    }
}
