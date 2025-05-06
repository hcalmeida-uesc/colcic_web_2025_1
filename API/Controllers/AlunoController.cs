using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ddd_project.App.Services;
using ddd_project.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using ddd_project.Domain.Contracts;
using ddd_project.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace ddd_project.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Aluno>> GetAllAlunos()
        {
            var alunos = _alunoRepository.GetAll();

            return Ok(alunos.ToArray());
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Aluno> Post([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest("Aluno não pode ser nulo.");

            var alunoSalvo = _alunoRepository.Add(aluno);
            return CreatedAtAction(nameof(GetAllAlunos), alunoSalvo);
        }

        [HttpPut]
        [Route("atividade")]
        public ActionResult<Aluno> AssociarAtividade(Guid alunoId, Guid atividadeId, int ch = 0)
        {
            var aluno = _alunoRepository.AddAtividade(alunoId, atividadeId, ch);
            if (aluno == null)
                return NotFound("Aluno ou Atividade não encontrados.");

            return Ok(aluno);
        }

    }
    
}
