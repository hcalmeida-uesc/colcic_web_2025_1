using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ddd_project.App.Services;
using ddd_project.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ddd_project.Controllers
{
    [Route("api/v0.1/[controller]")]
    [ApiController]
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
