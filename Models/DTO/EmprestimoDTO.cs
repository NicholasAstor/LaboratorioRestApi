using System.Diagnostics.Eventing.Reader;
using LaboratorioRestApi.Models.DTO;

namespace LaboratorioRestApi.Models.DTO
{
    public class EmprestimoDTO
    {
        public long Id { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Entregue { get; set; }
        public ListLivroEmprestimoDTO Livro { get; set; }
    }
}