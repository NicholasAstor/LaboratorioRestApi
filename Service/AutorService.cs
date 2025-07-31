using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repository.Interface;
using LaboratorioRestApi.Service.Interface;

namespace LaboratorioRestApi.Service
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repo;

        public AutorService(IAutorRepository repo) =>_repo = repo;

        public async Task<Autor> GetAutorByLastName(string name) => await _repo.GetLastName(name);

        public async Task<Autor> CreateAutor(Autor autor) => await _repo.Create(autor);
        public async Task<Autor> UpdateAutor(Autor autor) => await _repo.Update(autor);
    }
}