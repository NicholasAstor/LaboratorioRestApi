using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Repository.Interface;
using LaboratorioRestApi.Service.Interface;

namespace LaboratorioRestApi.Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repo;

        public LivroService(ILivroRepository repo) => _repo = repo;

        public async Task<Livro> CreateLivro(Livro livro) => await _repo.Create(livro);
        public async Task<IEnumerable<LivroDTO>> GetAllLivros()
        {
            var livros = await _repo.GetAll();

            var result = livros.Select(l => new LivroDTO
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autores = l.Autores.Select(a => new ListAutorLivroDTO
                {
                    Id = a.Id,
                    PrimeiroNome = a.PrimeiroNome,
                    SegundoNome = a.SegundoNome
                }).ToList()
            });

            return result;
        }
        public async Task<IEnumerable<LivroDTO>> GetLivroByAutor(long idAutor)
        {
            var livros = await _repo.GetByAutor(idAutor);

            var result = livros.Select(l => new LivroDTO
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autores = l.Autores.Select(a => new ListAutorLivroDTO
                {
                    Id = a.Id,
                    PrimeiroNome = a.PrimeiroNome,
                    SegundoNome = a.SegundoNome
                }).ToList()
            });

            return result;
        }
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
                    Disponivel = emprestimo == null || emprestimo.Entregue,
                    DataDevolucao = emprestimo?.DataDevolucao

                });
            }

            return result;
        }

        public async Task AddAutorToTheBook(long idLivro, long idAutor) => await _repo.AddAutorLivro(idLivro, idAutor);
    }
}