namespace LaboratorioRestApi.Models.DTO
{
    public class LivroDTO
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public List<ListAutorLivroDTO> Autores { get; set; } = new List<ListAutorLivroDTO>();
    }
}