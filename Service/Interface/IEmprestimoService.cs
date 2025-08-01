using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;

namespace LaboratorioRestApi.Service.Interface
{
    public interface IEmprestimoService
    {
        Task<Emprestimo> CreateEmprestimo(long idLivro);
        Task<double> UpdateEmprestimo(long id, DateTime dataEntrega);
        Task<EmprestimoDTO> GetEmprestimoAtivoByLivro(int livroId);
    }
}