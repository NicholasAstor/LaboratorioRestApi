using System.ComponentModel.DataAnnotations;

namespace LaboratorioRestApi.Models
{
    public class Autor
    {
        [Key]
        public long Id { get; set; }
        public required string PrimeiroNome { get; set; }
        public required string SegundoNome { get; set; }
        public ICollection<Livro> Livros { get; set; } = new List<Livro>();// many to many relationship
    }
}