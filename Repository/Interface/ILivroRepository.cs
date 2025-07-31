using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repository.Interface
{
    public interface ILivroRepository
    {
        Task<Livro> Create(Livro livro);
        Task<IEnumerable<Livro>> GetAll();
        Task<IEnumerable<Livro>> GetByAutor(int idAutor);
    }
}