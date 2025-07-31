using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaContext _db;
        public AutorRepository(BibliotecaContext db) => _db = db;
        public async Task<Autor?> GetLastName(string name) => await _db.Autores
        .FirstOrDefaultAsync(a => a.SegundoNome == name);

        public async Task<Autor> Create(Autor autor)
        {
            if (autor != null)
            {
                await _db.Autores.AddAsync(autor);
                await _db.SaveChangesAsync();
                return autor;
            }

            throw new Exception("Erro ao criar Autor");
        }

        public async Task<Autor> Update(Autor autor)
        {
            var autorAtualiza = await _db.Autores.FirstOrDefaultAsync(a => a.Id == autor.Id);

            if (autorAtualiza != null)
            {
                autorAtualiza.PrimeiroNome = autor.PrimeiroNome;
                autorAtualiza.SegundoNome = autor.SegundoNome;
                await _db.SaveChangesAsync();
                return autorAtualiza;
            }
            
            throw new Exception("Erro ao atualizar o Autor");
        }
    }
}