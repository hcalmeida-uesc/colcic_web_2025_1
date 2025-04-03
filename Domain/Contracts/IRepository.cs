using System;

namespace ddd_project.Domain.Contracts;

public interface IRepository<T> where T : class
{
   T GetById(Guid id);
   ICollection<T> GetAll();
   void Add(T entity);
   void Update(T entity);
   void Delete(Guid id);
 }
