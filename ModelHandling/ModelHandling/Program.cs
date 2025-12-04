using Microsoft.EntityFrameworkCore;
using ModelHandling.Data;
using Microsoft.AspNetCore.Identity;
using ModelHandling.Areas.Identity.Data;

namespace ModelHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<AppDbContext>(
                x => x.UseSqlServer(builder.Configuration.GetConnectionString("Connect")));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ModelHandlingContext>();

            builder.Services.AddDbContext<AppDbContext>(
               x => x.UseSqlServer(builder.Configuration.GetConnectionString("ModelHandlingContextConnection")));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ModelHandlingContext>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Create}/{id?}");

            app.Run();
        }
    }
}
