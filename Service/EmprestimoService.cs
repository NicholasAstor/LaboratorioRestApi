using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repository.Interface;
using LaboratorioRestApi.Service.Interface;

namespace LaboratorioRestApi.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repo;

        public EmprestimoService(IEmprestimoRepository repo) => _repo = repo;

        public async Task<Emprestimo> CreateEmprestimo(Emprestimo emprestimo) => await _repo.Create(emprestimo);

        public async Task<Emprestimo> UpdateEmprestimo(Emprestimo emprestimo) => await _repo.Update(emprestimo);

        public async Task<Emprestimo> GetEmprestimoAtivoByLivro(int livroId) => await _repo.Get(livroId);
    }
}