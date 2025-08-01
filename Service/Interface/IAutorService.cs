using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;

namespace LaboratorioRestApi.Service.Interface
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorDTO>> GetAutorByLastName(string name);
        Task<Autor> CreateAutor(Autor autor);
        Task<Autor> UpdateAutor(long id, Autor autor);
    }
}