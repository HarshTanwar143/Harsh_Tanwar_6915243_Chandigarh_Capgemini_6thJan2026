using EfCoreCodeBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeBooks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var cs1 = builder.Configuration.GetConnectionString("cs1");

            builder.Services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(cs1));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Serve static files from wwwroot
            app.UseStaticFiles();

            // Routing and authorization middleware
            app.UseRouting();
            app.UseAuthorization();

            // Default route should point to the Book controller
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
