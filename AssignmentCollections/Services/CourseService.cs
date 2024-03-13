using AssignmentCollections.Entities;
using AssignmentCollections.Mappers;
using AssignmentCollections.Models.Requests;
using AssignmentCollections.Models.Responses;
using AssignmentCollections.Repositories;

namespace AssignmentCollections.Services;

public class CourseService
{
    private readonly IRepository<CourseEntity> _courseRepository;

    public CourseService(IRepository<CourseEntity> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public CourseResponseDto CreateCourse(CourseRequestDto courseRequestDto)
    {
        var newCourse = new CourseEntity
        {
            Title = courseRequestDto.Title,
            Image = courseRequestDto.ImagePath,
            Color = courseRequestDto.Color
        };

        return (CourseResponseDto)AutoMapper.MapEntityToResponseDto(_courseRepository.Save(newCourse));
    }

    public CourseResponseDto GetCourseById(Guid id) =>
        (CourseResponseDto)AutoMapper.MapEntityToResponseDto(_courseRepository.GetById(id));

    public IEnumerable<CourseResponseDto?> GetAllCourses()
    {
        return _courseRepository.GetAll()
            .Select(entity => AutoMapper.MapEntityToResponseDto(entity) as CourseResponseDto).ToList();
    }

    public CourseResponseDto UpdateCourse(Guid id, CourseRequestDto updateRequest)
    {
        var existingCourse = _courseRepository.GetById(id);
        existingCourse.Title = updateRequest.Title;
        existingCourse.Color = updateRequest.Color;
        existingCourse.EnrollType = updateRequest.EnrollType;
        existingCourse.Image = updateRequest.ImagePath;

        return (CourseResponseDto)AutoMapper.MapEntityToResponseDto(_courseRepository.Update(id, existingCourse));
    }

    public void RemoveCourseById(Guid id) => _courseRepository.DeleteById(id);
}