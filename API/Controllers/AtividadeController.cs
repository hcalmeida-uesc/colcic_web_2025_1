using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain;
using ddd_project.Domain.Entities;
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

        // [HttpGet]
        // public ActionResult<Atividade> GetAll()
        // {
        //     var atividade = _atividadeService.GetAll();
        //     return Ok(atividade);
        // }
        
    }
}
