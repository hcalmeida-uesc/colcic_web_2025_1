using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using ddd_project.Domain.Contracts;

namespace ddd_project.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(
            IAlunoService alunoService,
            IAlunoRepository alunoRepository)
        {
            _alunoService = alunoService;
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAllAlunos()
        {
            var alunos = _alunoRepository.GetAll();
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
