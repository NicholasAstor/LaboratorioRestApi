using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repository.Interface
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> Create(Emprestimo emprestimo);
        Task<Emprestimo> Update(Emprestimo emprestimo);
        Task<Emprestimo> Get(long livroId);//Registros em aberto do livro 
    }
}