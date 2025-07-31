using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaContext _db;

        public EmprestimoRepository(BibliotecaContext db) => _db = db;
        public async Task<Emprestimo> Create(Emprestimo emprestimo)
        {
            if (emprestimo != null)
            {
                var bookIsAlreadyTaken = await _db.Emprestimos.FirstOrDefaultAsync(e => e.Livro.Id == emprestimo.Livro.Id);

                if (bookIsAlreadyTaken != null)
                {
                    throw new Exception("Emprestimo já existe");
                }

                emprestimo.DataDevolucao = emprestimo.DataRetirada.AddDays(7);
                emprestimo.Entregue = false; 

                await _db.Emprestimos.AddAsync(emprestimo);
                await _db.SaveChangesAsync();
                return emprestimo;
            }

            throw new Exception("Erro ao criar Emprestimo");
        }
        public async Task<Emprestimo> Update(Emprestimo emprestimo)
        {
            var atualizaEmprestimo = await _db.Emprestimos.FirstOrDefaultAsync(e => e.Id == emprestimo.Id);

            if (atualizaEmprestimo != null)
            {
                atualizaEmprestimo.DataDevolucao = emprestimo.DataDevolucao;
                atualizaEmprestimo.DataRetirada = emprestimo.DataRetirada;
                atualizaEmprestimo.Entregue = emprestimo.Entregue;
                atualizaEmprestimo.Livro = atualizaEmprestimo.Livro;
                await _db.SaveChangesAsync();
                return atualizaEmprestimo;
            }
            throw new Exception("Erro ao atualizar Emprestimo");
        }
        public async Task<Emprestimo?> Get(long livroId) => await _db.Emprestimos
        .FirstOrDefaultAsync(e => e.Livro.Id == livroId && e.Entregue == false);
    }
}