using DemoApplication.Models.Context;
using Microsoft.EntityFrameworkCore;
namespace DemoApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("myconn");


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<EmployeeDbContext>(options => { options.UseSqlServer(connection);});
       
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}