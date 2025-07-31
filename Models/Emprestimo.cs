using System.ComponentModel.DataAnnotations;

namespace LaboratorioRestApi.Models
{
    public class Emprestimo
    {
        [Key]
        public long Id { get; set; }
        public required DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public required bool Entregue { get; set; }   
        public required Livro Livro { get; set; } // funciona como LivroId e já faz a FK
    }
}