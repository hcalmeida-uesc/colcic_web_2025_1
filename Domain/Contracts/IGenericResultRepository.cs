using System;
using ddd_project.Domain.ResultPattern;

namespace ddd_project.Domain.Contracts;

public interface IGenericResultRepository<T>
{
    public Result<ICollection<T>> GetAll();
   public Result<T> GetById(Guid id);
   public Result<T> Add(T entity);
   public Result<T> Update(T entity);
   public Result<T> Delete(Guid id);
}
