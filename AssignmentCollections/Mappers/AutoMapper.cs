using AssignmentCollections.Entities;
using AssignmentCollections.Models;
using AssignmentCollections.Models.Requests;
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

    public static object MapDtoToEntity(IBaseDto dto)
    {
        if (dto is CourseRequestDto courseRequestDto)
        {
            return new CourseEntity()
            {
                Color = courseRequestDto.Color, Title = courseRequestDto.Title,
                EnrollType = courseRequestDto.EnrollType, Image = courseRequestDto.ImagePath
            };
        }

        throw new InvalidCastException();
    }
}