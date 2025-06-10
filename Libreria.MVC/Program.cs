using Libreria.Modelos;
using Librerria.API.Consumer;

namespace Libreria.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<Autor>.EndPoint = "https://localhost:7041/api/Autores";
            Crud<Editorial>.EndPoint = "https://localhost:7041/api/Editoriales";
            Crud<Libro>.EndPoint = "https://localhost:7041/api/Libros";
            Crud<Pais>.EndPoint = "https://localhost:7041/api/Paises";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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
