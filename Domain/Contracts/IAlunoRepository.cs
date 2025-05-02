using System;
using ddd_project.Domain.ResultPattern;

namespace ddd_project.Domain.Contracts;

public interface IAlunoRepository:IGenericRepository<Aluno>
{
   public Result<ICollection<Aluno>> GetAlunosByAtividade(Guid atividadeId);
   public Result<Aluno?> AddAtividade(Guid alunoId, Guid atividadeId, int ch = 0);
}
