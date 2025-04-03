using System;
using ddd_project.Database.Mockups;
using ddd_project.Domain.Contracts;

namespace ddd_projectq.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
   protected readonly MemDatabase _context;

   protected Repository()
   {
      _context = new MemDatabase();
   }
   protected Repository(MemDatabase context)
   {
      _context = context;
   }
   public void Add(T entity)
   {
      _context.Add(entity);
   }

   public void Delete(Guid id)
   {
      _context.Delete<T>(id);
   }

   public ICollection<T> GetAll()
   {
      return _context.GetAll<T>();
   }

   public T GetById(Guid id)
   {
      return _context.GetById<T>(id);
   }

   public void Update(T entity)
   {
      _context.Update(entity);
   }
}
