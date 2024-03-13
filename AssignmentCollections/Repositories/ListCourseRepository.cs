using AssignmentCollections.Entities;

namespace AssignmentCollections.Repositories;

public class ListCourseRepository : IRepository<CourseEntity>
{
    private readonly List<CourseEntity> _courseList = new();

    public CourseEntity GetById(Guid id) => _courseList.First(entity => entity.Id.Equals(id));

    public List<CourseEntity> GetAll() => new(_courseList);

    public CourseEntity Save(CourseEntity entity)
    {
        entity.Id = Guid.NewGuid();
        entity.UpdatedTime = entity.CreatedTime;
        _courseList.Add(entity);

        return entity;
    }

    public void Delete(CourseEntity entity) => _courseList.Remove(entity);

    public CourseEntity Update(CourseEntity entity)
    {
        var entityToUpdate = GetById(id: entity.Id);
        entity.CopyTo(entityToUpdate);

        return entityToUpdate;
    }
}