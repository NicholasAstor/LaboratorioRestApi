using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repository.Interface
{
    public interface IAutorRepository
    {
        Task<Autor> GetLastName(string name);
        Task<Autor> Create(Autor autor);
        Task<Autor> Update(Autor autor);
    }
}