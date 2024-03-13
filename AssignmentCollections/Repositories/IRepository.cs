using AssignmentCollections.Entities;

namespace AssignmentCollections.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    T GetById(Guid id);
    List<T> GetAll();
    T Save(T entity);
    void Delete(T entity);
    T Update(T entity);
}