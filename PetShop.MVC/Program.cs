using Mailing.MailKitImplementations;
using Mailing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShop.BusinessLogic;
using PetShop.BusinessLogic.Constants;
using PetShop.DA;
using PetShop.DA.DataContext;
using PetShop.DA.DataContext.Entities;
using System.Threading.Tasks;
namespace PetShop.MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")
                );
            });

            builder.Services.AddDataAccessLayerServices(builder.Configuration);
            builder.Services.AddBusinessLogicLayerServices();

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                //options.User.RequireUniqueEmail = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddScoped<IMailService, MailKitMailService>();

            FilePathConstants.ReviewImagePath = Path.Combine(builder.Environment.WebRootPath, "images", "reviews");
            FilePathConstants.ProductImagePath = Path.Combine(builder.Environment.WebRootPath, "images", "products");
            FilePathConstants.ProfileImagePath = Path.Combine(builder.Environment.WebRootPath, "images", "users");


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //using (var scope = app.Services.CreateScope()) {
            //    var dataInitializer = scope.ServiceProvider.GetRequiredService<DataInitializer>();
            //    await dataInitializer.Initialize();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
