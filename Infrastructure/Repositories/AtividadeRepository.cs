using System;
using ddd_project.Domain;
using ddd_project.Domain.Contracts;
using ddd_project.Domain.ResultPattern;
using ddd_project.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;

namespace ddd_project.Infrastructure.Repositories;

public class AtividadeRepository : IAtividadeRepository
{
   private readonly ColcicExtensaoContext _context;

   public AtividadeRepository(ColcicExtensaoContext context)
   {
      _context = context;
   }

   public Atividade Add(Atividade entity)
   {
      _context.Atividades.Add(entity);
      _context.SaveChanges();
      return entity;
   }

   public Atividade Delete(Guid id)
   {
      throw new NotImplementedException();
   }

   public ICollection<Atividade> GetAll()
   {
      return _context.Atividades.Include(a => a.Alunos).ToList();
   }

   public ICollection<Atividade> GetAllAtividadesByAluno(Guid alunoId)
   {
      throw new NotImplementedException();
   }

   public Atividade GetById(Guid id)
   {
      throw new NotImplementedException();
   }

   public Atividade Update(Atividade entity)
   {
      throw new NotImplementedException();
   }
}

