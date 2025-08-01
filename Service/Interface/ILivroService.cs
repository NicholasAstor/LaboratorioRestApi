using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;

namespace LaboratorioRestApi.Service.Interface
{
    public interface ILivroService
    {
        Task<Livro> CreateLivro(Livro livro);
        Task<IEnumerable<LivroDTO>> GetAllLivros();
        Task<IEnumerable<LivroDTO>> GetLivroByAutor(long idAutor);
        Task<IEnumerable<ListLivroStatusDTO>> GetLivrosPorAutor(long autorId);
        Task AddAutorToTheBook(long idLivro, long idAutor);
    }
}