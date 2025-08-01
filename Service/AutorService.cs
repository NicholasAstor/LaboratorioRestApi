using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Repository.Interface;
using LaboratorioRestApi.Service.Interface;

namespace LaboratorioRestApi.Service
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repo;

        public AutorService(IAutorRepository repo) =>_repo = repo;

        public async Task<IEnumerable<AutorDTO>> GetAutorByLastName(string name)
        {
            var autores = await _repo.GetLastName(name);

            var result = autores.Select(a => new AutorDTO
            {
                Id = a.Id,
                PrimeiroNome = a.PrimeiroNome,
                SegundoNome = a.SegundoNome,
                Livros = a.Livros.Select(l => new ListLivroAutorDTO
                {
                    Id = l.Id,
                    Titulo = l.Titulo
                }).ToList()
            });

            return result;
        }
        public async Task<Autor> CreateAutor(Autor autor) => await _repo.Create(autor);
        public async Task<Autor> UpdateAutor(long id, Autor autor) => await _repo.Update(id, autor);
    }
}