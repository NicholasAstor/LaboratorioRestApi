namespace LaboratorioRestApi.Models.DTO
{
    public class AutorDTO
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public List<ListLivroAutorDTO> Livros { get; set; } = new List<ListLivroAutorDTO>();
    }
}