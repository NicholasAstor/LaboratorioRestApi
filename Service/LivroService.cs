using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Repository.Interface;
using LaboratorioRestApi.Service.Interface;

namespace LaboratorioRestApi.Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repo;

        public LivroService(ILivroRepository repo)
        {
            _repo = repo;
        }

        public async Task<Livro> CreateLivro(Livro livro) => await _repo.Create(livro);
        public async Task<IEnumerable<Livro>> GetAllLivros() => await _repo.GetAll();
        public async Task<IEnumerable<Livro>> GetLivroByAutor(long idAutor) => await _repo.GetByAutor(idAutor);
        public async Task<IEnumerable<ListLivroStatusDTO>> GetLivrosPorAutor(long autorId)
        {
            var livros = await _repo.GetByAutor(autorId);
            var result = new List<ListLivroStatusDTO>();

            foreach (var livro in livros)
            {
                var emprestimo = await _repo.GetEmprestimoByLivro(livro.Id);

                result.Add(new ListLivroStatusDTO
                {
                    LivroId = livro.Id,
                    Titulo = livro.Titulo,
                    Disponivel = !emprestimo.Entregue ? true : false,
                    DataDevolucao = emprestimo.DataDevolucao

                });
            }

            return result;
        }
    }
}