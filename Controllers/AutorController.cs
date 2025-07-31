using System.Diagnostics.Eventing.Reader;
using LaboratorioRestApi.Models;
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
    }
}