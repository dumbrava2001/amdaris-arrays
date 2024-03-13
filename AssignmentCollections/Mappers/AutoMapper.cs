using AssignmentCollections.Entities;
using AssignmentCollections.Models.Responses;

namespace AssignmentCollections.Mappers;

public static class AutoMapper
{
    public static object MapEntityToResponseDto(BaseEntity entity)
    {
        if (entity is CourseEntity courseEntity)
        {
            return new CourseResponseDto(courseEntity.Id, courseEntity.Title, courseEntity.Color);
        }

        throw new InvalidCastException();
    }
}