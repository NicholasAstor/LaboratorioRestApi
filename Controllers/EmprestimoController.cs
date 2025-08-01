using LaboratorioRestApi.Models;
using LaboratorioRestApi.Models.DTO;
using LaboratorioRestApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoService _service;

        public EmprestimoController(IEmprestimoService service) => _service = service;

        [HttpPost("{id}")]
        public async Task<ActionResult<Emprestimo>> Create(long id)
        {
            var createdEmprestimo = await _service.CreateEmprestimo(id);
            return Ok(createdEmprestimo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Emprestimo>> Update(long id, [FromBody] DataEntregaDTO dataEntrega)
        {
            var updatedEmprestimo = await _service.UpdateEmprestimo(id, dataEntrega.DataEntrega);
            return Ok(updatedEmprestimo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmprestimoDTO>> GetByLivro(int id)
        {
            var emprestimoByLivro = await _service.GetEmprestimoAtivoByLivro(id);

            if (emprestimoByLivro == null)
            {
                return NotFound("Não existe empréstimo para esse livro");
            }
            
            return Ok(emprestimoByLivro);
        }
    }
}