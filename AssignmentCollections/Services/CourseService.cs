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

    public IEnumerable<CourseResponseDto?> GetAllCourses()
    {
        return _courseRepository.GetAll()
            .Select(entity => AutoMapper.MapEntityToResponseDto(entity) as CourseResponseDto).ToList();
    }
}