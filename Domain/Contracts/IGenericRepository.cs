using System;
using ddd_project.Domain.ResultPattern;

namespace ddd_project.Domain.Contracts;

public interface IGenericRepository<T>
{
    public ICollection<T> GetAll();
   public T GetById(Guid id);
   public T Add(T entity);
   public T Update(T entity);
   public T Delete(Guid id);
}
