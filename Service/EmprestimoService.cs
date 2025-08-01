using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Repository.Interface;
using LaboratorioRestApi.Service.Interface;

namespace LaboratorioRestApi.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repo;

        public EmprestimoService(IEmprestimoRepository repo) => _repo = repo;

        public async Task<Emprestimo> CreateEmprestimo(long idLivro) => await _repo.Create(idLivro);

        public async Task<double> UpdateEmprestimo(long id, DateTime dataEntrega) => await _repo.Update(id, dataEntrega);

        public async Task<EmprestimoDTO> GetEmprestimoAtivoByLivro(int livroId)
        {
            var emprestimo = await _repo.Get(livroId);

            var result = new EmprestimoDTO
            {
                Id = emprestimo.Id,
                DataRetirada = emprestimo.DataRetirada,
                DataDevolucao = emprestimo.DataDevolucao,
                Entregue = emprestimo.Entregue,
                Livro = new ListLivroEmprestimoDTO
                {
                    Id = emprestimo.Livro.Id,
                    Titulo = emprestimo.Livro.Titulo
                }
            };

            return result;
        } 
    }
}