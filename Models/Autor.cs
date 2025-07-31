using System.ComponentModel.DataAnnotations;

namespace LaboratorioRestApi.Models
{
    public class Autor
    {
        [Key]
        public long Id { get; set; }
        public required string primeiroNome { get; set; }
        public required string segundoNome { get; set; }
        public ICollection<Livro> Livros { get; set; } // many to many relationship
    }
}