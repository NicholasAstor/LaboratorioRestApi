using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Service.Interface
{
    public interface IEmprestimoService
    {
        Task<Emprestimo> CreateEmprestimo(Emprestimo emprestimo);
        Task<Emprestimo> UpdateEmprestimo(Emprestimo emprestimo);
        Task<Emprestimo> GetEmprestimoAtivoByLivro(int livroId);
    }
}