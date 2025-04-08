using System;
using ddd_project.Domain;
using ddd_project.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AlunoRepository : IAlunoRepository
{
   DbContext _context;
   public Aluno Add(Aluno entity)
   {
      throw new NotImplementedException();
   }

   public Aluno Delete(Guid id)
   {
      throw new NotImplementedException();
   }

   public ICollection<Aluno> GetAll()
   {
      throw new NotImplementedException();
   }

   public ICollection<Aluno> GetAlunosByAtividade(Guid atividadeId)
   {
      throw new NotImplementedException();
   }

   public Aluno GetById(Guid id)
   {
      throw new NotImplementedException();
   }

   public Aluno Update(Aluno entity)
   {
      throw new NotImplementedException();
   }
}
