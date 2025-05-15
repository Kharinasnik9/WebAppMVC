using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAppMVC.Middlewares;
using WebAppMVC.Models.Db;

namespace WebAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Получаем строку подключения из appsettings.json
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // Регистрируем контекст БД

            builder.Services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(connection));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Регистрация репозиториев
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IRequestRepository, RequestRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();
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
