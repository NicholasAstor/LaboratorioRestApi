using System.Diagnostics.Eventing.Reader;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Service.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service) => _service = service;

        [HttpPost]
        public async Task<ActionResult<Livro>> Create([FromBody] Livro livro) // Criar um autor no banco
        {
            var createdLivro = await _service.CreateLivro(livro);
            return Ok(createdLivro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDTO>>> Get() // Get de todos os autores
        {
            var allLivros = await _service.GetAllLivros();
            if (allLivros != null)
            {
                return Ok(allLivros);
            }
            return NotFound("Nenhum livro encontrado!");
        }

        [HttpGet("autor/{id}")]
        public async Task<ActionResult<IEnumerable<LivroDTO>>> GetByAutor(long id) // Get por id do autor relacionado ao livro
        {
            var livrosByAutor = await _service.GetLivroByAutor(id);
            if (livrosByAutor != null)
            {
                return Ok(livrosByAutor);
            }
            return NotFound("Nenhum livro encontrado para esse autor");
        }

        [HttpGet("autor/status/{id}")]
        public async Task<ActionResult<IEnumerable<ListLivroStatusDTO>>> GetByAutorWithStatus(long id) // Funcionalidade de negócio proposta pelo professor (Get de livros pelo autor mostrando sua disponibilidade)
        {
            var livrosByAutorWithStatus = await _service.GetLivrosPorAutor(id);
            if (livrosByAutorWithStatus != null)
            {
                return Ok(livrosByAutorWithStatus);
            }
            return NotFound("Nenhum livro encontrado para esse autor");
        }

        [HttpPut("{livro}/autor/{autor}")]
        public async Task<ActionResult> AddAutor(long livro, long autor) // Relacionar um autor a um livro
        {
            await _service.AddAutorToTheBook(livro, autor);
            return Ok();
        }
    }
}