using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repository.Interface
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetLastName(string name); // funcionando
        Task<Autor> Create(Autor autor); // funcionando
        Task<Autor> Update(long id, Autor autor); // funcionando
    }
}