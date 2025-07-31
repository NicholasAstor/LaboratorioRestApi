
using LaboratorioRestApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<BibliotecaContext>(options => options.UseNpgsql("HOST=localhost;Port=5432;Database=labrestapi;Username=postgres;Password=lab"));
        //repositories
        builder.Services.AddScoped<Repository.AutorRepository, Repository.AutorRepository>();
        builder.Services.AddScoped<Repository.Interface.IEmprestimoRepository, Repository.EmprestimoRepository>();
        builder.Services.AddScoped<Repository.Interface.ILivroRepository, Repository.LivroRepository>();
        //services
        builder.Services.AddScoped<Service.Interface.IAutorService, Service.AutorService>();
        builder.Services.AddScoped<Service.Interface.IEmprestimoService, Service.EmprestimoService>();
        builder.Services.AddScoped<Service.Interface.ILivroService, Service.LivroService>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
