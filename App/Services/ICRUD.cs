using System;

namespace ddd_project.App.Services;

public interface ICRUD<T> 
{
   // T GetById<T>(int id);
   ICollection<T> GetAll();
//    void Add<T>(T entity);
//    void Update<T>(T entity);
//    void Delete<T>(int id);
 }
