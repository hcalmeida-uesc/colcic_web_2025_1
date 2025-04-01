using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeService _atividadeService;
        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        [HttpGet]
        public ActionResult<Atividade> GetAtividade()
        {
            var atividade = _atividadeService.GetAtividade();
            return Ok(atividade);
        }
        
    }
}
