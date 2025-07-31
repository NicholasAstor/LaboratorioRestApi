using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _db;

        public LivroRepository(BibliotecaContext db) => _db = db;

        public async Task<Livro> Create(Livro livro)
        {
            if (livro != null)
            {
                await _db.Livros.AddAsync(livro);
                await _db.SaveChangesAsync();
                return livro;
            }
            throw new Exception("Erro ao criar Livro");
        }

        public async Task<IEnumerable<Livro>> GetAll() => await _db.Livros
        .Include(l => l.Autores)
        .ToListAsync();

        public async Task<IEnumerable<Livro>> GetByAutor(int idAutor) => await _db.Autores
        .Where(a => a.Id == idAutor)
        .SelectMany(a => a.Livros)
        .Include(l => l.Autores)
        .ToListAsync();
    }
}