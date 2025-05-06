using System;
using ddd_project.Domain;
using ddd_project.Domain.Contracts;
using ddd_project.Domain.ResultPattern;
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

   // public Result<Aluno> Add(Aluno entity)
   // {
   //    _context.Alunos.Add(entity);
   //    _context.SaveChanges();
   //    return Result<Aluno>.Success(entity);
   // }

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
      return _context.Alunos
         .Include(a => a.Atividades)
         .FirstOrDefault(a => a.Id == id) ?? throw new Exception("Aluno não encontrado.");
   }

   public Aluno Update(Aluno entity)
   {
      throw new NotImplementedException();
   }

   private AlunoAtividade? GetAlunoAtividade(Guid alunoId, Guid atividadeId)
   {
      return _context.AlunoAtividades
         .FirstOrDefault(a => a.AlunoId == alunoId && a.AtividadeId == atividadeId);
   }

   private AlunoAtividade? SetChAlunoAtividade(Guid alunoId, Guid atividadeId, int ch)
   {
      var alunoAtividade = GetAlunoAtividade(alunoId, atividadeId);

      if (alunoAtividade == null)
         return null;

      alunoAtividade.Ch = ch;
      _context.AlunoAtividades.Update(alunoAtividade);
      _context.SaveChanges();

      return alunoAtividade;
   }
   public Aluno? AddAtividade(Guid alunoId, Guid atividadeId, int ch = 0)
   {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == alunoId);
      var atividade = _context.Atividades.FirstOrDefault(a => a.Id == atividadeId);

      if (aluno == null || atividade == null)
         return null;

      aluno.Atividades.Add(atividade);
      _context.SaveChanges();

      ch = ch == 0 ? atividade.Ch : ch;
      if(SetChAlunoAtividade(alunoId, atividadeId, ch) == null)
         return null;
         
      return aluno;
   }
}
