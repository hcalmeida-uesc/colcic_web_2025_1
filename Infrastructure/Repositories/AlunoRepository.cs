using System;
using ddd_project.Domain;
using ddd_project.Domain.Contracts;
using ddd_project.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;

namespace ddd_project.Infrastructure.Repositories;

public class AlunoRepository : IAlunoRepository
{
   private readonly ColcicExtensaoContext _context;

   public AlunoRepository(ColcicExtensaoContext context)
   {
      _context = context;
   }

   public Aluno Add(Aluno entity)
   {
      _context.Alunos.Add(entity);
      _context.SaveChanges();
      return entity;
   }

   public Aluno Delete(Guid id)
   {
      throw new NotImplementedException();
   }

   public ICollection<Aluno> GetAll()
   {
      return _context.Alunos.Include(a => a.Atividades).ToList();
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

   public Aluno? AddAtividade(Guid alunoId, Guid atividadeId, int? ch = 0)
   {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == alunoId);
      var atividade = _context.Atividades.FirstOrDefault(a => a.Id == atividadeId);

      if (aluno == null || atividade == null)
         return null;

      aluno.Atividades.Add(atividade);
      _context.SaveChanges();

      var alunoatividade = _context.AlunoAtividades.FirstOrDefault(a => a.AtividadeId == atividadeId && a.AlunoId == alunoId);
      
      alunoatividade.Ch = (int)ch;

      _context.AlunoAtividades.Update(alunoatividade);
      _context.SaveChanges();

      return aluno;
   }
}
