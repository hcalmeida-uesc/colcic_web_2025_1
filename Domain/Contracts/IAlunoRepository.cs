using System;

namespace ddd_project.Domain.Contracts;

public interface IAlunoRepository:IGenericRepository<Aluno>
{
   public ICollection<Aluno> GetAlunosByAtividade(Guid atividadeId);
   public Aluno? AddAtividade(Guid alunoId, Guid atividadeId, int ch = 0);
}
