using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ddd_project.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAllAlunos()
        {
            var alunos = _alunoService.GetAllAlunos();
            return Ok(alunos);
        }
    }
}
