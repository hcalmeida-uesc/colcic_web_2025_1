using System;

namespace ddd_project.Domain.Contracts;

public interface IAlunoRepository:IGenericRepository<Aluno>
{
   public ICollection<Aluno> GetAlunosByAtividade(Guid atividadeId);
}
