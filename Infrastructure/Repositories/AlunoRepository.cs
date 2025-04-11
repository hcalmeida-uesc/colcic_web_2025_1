using System;
using ddd_project.Domain;
using ddd_project.Domain.Contracts;
using ddd_project.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AlunoRepository : IAlunoRepository
{
   private readonly ColcicExtensaoContext _context;

   public AlunoRepository(ColcicExtensaoContext context)
   {
      _context = context;
   }

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
