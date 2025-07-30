using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Data
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Livro> Livros { get; set; }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql()
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        }
    }
}