using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repository.Interface
{
    public interface ILivroRepository
    {
        Task<Livro> Create(Livro livro); // funcionando
        Task<IEnumerable<Livro>> GetAll(); // funcionando
        Task<IEnumerable<Livro>> GetByAutor(long idAutor); // funcionando
        Task<Emprestimo?> GetEmprestimoByLivro(long livroId); // funcionando
        Task AddAutorLivro(long idLivro, long idAutor); // funcionando
    }
}