using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaContext _db;

        public EmprestimoRepository(BibliotecaContext db) => _db = db;
        public async Task<Emprestimo> Create(long idLivro)
        {
            var bookIsAlreadyTaken =  await _db.Emprestimos.FirstOrDefaultAsync(e => e.Livro.Id == idLivro && !e.Entregue);

            if (bookIsAlreadyTaken != null)
            {
                throw new Exception("Este livro não esta disponivel para emprestimo");
            }

            var livro = await _db.Livros.FirstOrDefaultAsync(l => l.Id == idLivro);

            if (livro != null)
            {
                var emprestimo = new Emprestimo
                {
                    DataRetirada = DateTime.Now.ToUniversalTime(),
                    DataDevolucao = DateTime.Now.AddDays(7).ToUniversalTime(),
                    Entregue = false,
                    Livro = livro
                };
                await _db.Emprestimos.AddAsync(emprestimo);
                await _db.SaveChangesAsync();
                return emprestimo;
            }

            throw new Exception("Livro não encontrado");

            // if (emprestimo != null)
            // {
            //     var bookIsAlreadyTaken = await _db.Emprestimos.FirstOrDefaultAsync(e => e.Livro.Id == emprestimo.Livro.Id);

            //     if (bookIsAlreadyTaken != null)
            //     {
            //         throw new Exception("Emprestimo já existe");
            //     }

            //     emprestimo.DataRetirada = DateTime.Now;
            //     emprestimo.DataDevolucao = emprestimo.DataRetirada.AddDays(7);
            //     emprestimo.Entregue = false; 

            //     await _db.Emprestimos.AddAsync(emprestimo);
            //     await _db.SaveChangesAsync();
            //     return emprestimo;
            // }

        }
        public async Task<double> Update(long id, DateTime dataEntrega)
        {
            var atualizaEmprestimo = await _db.Emprestimos.FirstOrDefaultAsync(e => e.Id == id);

            var multa = 0.0;

            if (atualizaEmprestimo != null)
            {
                atualizaEmprestimo.Entregue = true;
                atualizaEmprestimo.DataDevolucao = dataEntrega.ToUniversalTime();

                TimeSpan diferenca = atualizaEmprestimo.DataDevolucao.ToUniversalTime() - atualizaEmprestimo.DataRetirada;

                int diasDiferenca = (int)diferenca.TotalDays;

                if (diasDiferenca > 7)
                {
                    multa = 10.0;
                    while (diasDiferenca > 7)
                    {
                        diasDiferenca--;
                        multa = (multa * 0.2) + multa;
                    }
                }

                await _db.SaveChangesAsync();
                return multa;
            }
            throw new Exception("Erro ao atualizar Emprestimo");
        }
        public async Task<Emprestimo?> Get(long livroId) => await _db.Emprestimos
        .Include(e => e.Livro)
        .FirstOrDefaultAsync(e => e.Livro.Id == livroId && e.Entregue == false);
    }
}