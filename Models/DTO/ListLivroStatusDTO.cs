namespace LaboratorioRestApi.Models.DTO
{    
    public class ListLivroStatusDTO
    {
        public long LivroId { get; set; }
        public required string Titulo { get; set; }
        public bool Disponivel { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}