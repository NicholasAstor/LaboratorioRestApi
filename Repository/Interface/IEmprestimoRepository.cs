using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;

namespace LaboratorioRestApi.Repository.Interface
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> Create(long idLivro); // funcionando
        Task<double> Update(long id, DateTime dataEntrega); // funcionando
        Task<Emprestimo> Get(long livroId);//Registros em aberto do livro 
    }
}