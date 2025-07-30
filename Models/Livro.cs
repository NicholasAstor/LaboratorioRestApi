using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace LaboratorioRestApi.Models
{
    public class Livro
    {
        [Key]
        public long Id { get; set; }
        public required string Titulo { get; set; }
    }
}