using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Service.Interface
{
    public interface IAutorService
    {
        Task<Autor> GetAutorByLastName(string name);
        Task<Autor> CreateAutor(Autor autor);
        Task<Autor> UpdateAutor(Autor autor);
    }
}