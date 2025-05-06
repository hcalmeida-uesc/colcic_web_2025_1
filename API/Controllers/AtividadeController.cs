using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain;
using ddd_project.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeRepository _atividadeRepository;
        public AtividadeController(IAtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Atividade>> GetAtividade()
        {
            var atividade = _atividadeRepository.GetAll();
            return Ok(atividade.ToList());
        }

        [HttpPost]
        public ActionResult<Atividade> Post([FromBody] Atividade atividade)
        {
            if (atividade == null)
                return BadRequest("Atividade não pode ser nulo.");

            var atividadeSalva = _atividadeRepository.Add(atividade);
            return CreatedAtAction(nameof(GetAtividade), new { id = atividadeSalva.Id }, atividadeSalva);
        }
        
    }
}
