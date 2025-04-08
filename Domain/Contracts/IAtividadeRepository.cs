using System;

namespace ddd_project.Domain.Contracts;

public interface IAtividadeRepository:IGenericRepository<Atividade>
{
   public ICollection<Atividade> GetAllAtividadesByAluno(Guid alunoId);
}
