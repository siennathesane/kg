using System.Collections;
using Schema.NET;

namespace necronomicon.Models; 

public interface IRepository<T> where T : class {
    T Get(object id);
    IQueryable<T> GetAll();
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void SubmitChanges();
}
