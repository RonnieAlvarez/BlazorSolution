using BlazorCrud.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorCrud.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Cadena de conexion con la base de datos
            builder.Services.AddDbContext<DbcrudBlazorContext>(opciones=> 
            {
                opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));    
            });

            //AQUI SE ESTAN CREANDO LOS CORS para que se puedan comunicar 
            builder.Services.AddCors(opciones => {
                opciones.AddPolicy("nuevaPolitica", app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // Aqui se llaman los CORS
            app.UseCors("nuevaPolitica");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
