using System.Diagnostics.Eventing.Reader;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : Controller
    {
        private readonly IAutorService _service;

        public AutorController(IAutorService service) => _service = service;

        [HttpPost]
        public async Task<ActionResult<Livro>> Create([FromBody] Autor autor)
        {
            var createdAutor = await _service.CreateAutor(autor);
            return Ok(createdAutor);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetByLastName(string name)
        {
            var autores = await _service.GetAutorByLastName(name);
            if (autores == null)
            {
                return NotFound("Não temos autores com esse sobrenome registrados");
            }
            return Ok(autores);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Autor>> UpdateAutor(long id, [FromBody] Autor autor)
        {
            var updatedAutor = await _service.UpdateAutor(id, autor);
            return Ok(updatedAutor);
        }
    }
}