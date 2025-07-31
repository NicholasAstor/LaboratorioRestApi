
using LaboratorioRestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LaboratorioRestApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<BibliotecaContext>(options => options.UseNpgsql("HOST=localhost;Port=5432;Database=labrestapi;Username=postgres;Password=lab"));
        //repositories
        builder.Services.AddScoped<Repository.Interface.IAutorRepository, Repository.AutorRepository>();
        builder.Services.AddScoped<Repository.Interface.IEmprestimoRepository, Repository.EmprestimoRepository>();
        builder.Services.AddScoped<Repository.Interface.ILivroRepository, Repository.LivroRepository>();
        //services
        builder.Services.AddScoped<Service.Interface.IAutorService, Service.AutorService>();
        builder.Services.AddScoped<Service.Interface.IEmprestimoService, Service.EmprestimoService>();
        builder.Services.AddScoped<Service.Interface.ILivroService, Service.LivroService>();

        builder.Services.AddControllers();

        //swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();


        var app = builder.Build();
    

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
