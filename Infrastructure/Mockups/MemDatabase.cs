using System;
using ddd_project.Domain.Entities;
namespace ddd_project.Database.Mockups;

public class MemDatabase
{
   private static List<Aluno> _alunos = new();

   public MemDatabase(){
      _alunos.AddRange(new List<Aluno>{
         new Aluno ("João Silva","20251001" ),
         new Aluno ("Maria Oliveira", "20251002"),
         new Aluno ("Carlos Santos", "20251003"),
         new Aluno ("Ana Costa", "20251004"),
      });
   }

   public void Add<T>(T entity)
   {
      if (entity is Aluno aluno)
      {
         _alunos.Add(aluno);
      }
      else
      {
         throw new ArgumentException("Tipo de entidade não suportado.");
      }
   }

   public T GetById<T>(Guid id)
   {
      if (typeof(T) == typeof(Aluno))
      {
         var aluno = _alunos.FirstOrDefault(a => a.Id == id);
         if (aluno == null)
         {
            throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
         }
         return (T)(object)aluno;
      }
      else
      {
         throw new ArgumentException("Tipo de entidade não suportado.");
      }
   }

   public ICollection<T> GetAll<T>()
   {
      if (typeof(T) == typeof(Aluno))
      {
         return (ICollection<T>)_alunos;
      }
      else
      {
         throw new ArgumentException("Tipo de entidade não suportado.");
      }
   }

   public void Update<T>(T entity)
   {
      throw new NotImplementedException();
   }

   public void Delete<T>(Guid id)
   {
      throw new NotImplementedException();
   }
}
