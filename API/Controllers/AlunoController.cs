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

        [HttpPut]
        [Route("{matricula}/atividade")]
        public Aluno AssociarAtividade(string matricula, [FromBody] Atividade atividade, int? ch = null)
        {
            var aluno = _alunoService.GetAllAlunos().FirstOrDefault(a => a.Matricula == matricula);
            if (aluno == null)
            {
                return null; // or throw an exception
            }

            return _alunoService.AssociarAtividade(aluno, atividade, ch);
        }

    }
    
}
