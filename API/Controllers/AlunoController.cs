using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain.Entities;
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
        public AlunoController(IAlunoService alunoService, IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
            _alunoService = alunoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAllAlunos()
        {
            var alunos = _alunoRepository.GetAll();
            return Ok(alunos);
        }

        // [HttpPut]
        // [Route("{matricula}/atividade")]
        // public Aluno AssociarAtividade(string matricula, [FromBody] Atividade atividade, int? ch = null)
        // {
        //     var aluno = _alunoService.GetAll().FirstOrDefault(a => a.Matricula == matricula);
        //     if (aluno == null)
        //     {
        //         return null; // or throw an exception
        //     }
        //     _alunoService.AssociarAlunoAtividade(aluno, atividade, ch);

        //     return aluno;
        // }

    }
    
}
