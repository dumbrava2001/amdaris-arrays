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
        var newCourse = (CourseEntity)AutoMapper.MapDtoToEntity(courseRequestDto);
        var createdCurse = _courseRepository.Save(newCourse);
        var response = (CourseResponseDto)AutoMapper.MapEntityToResponseDto(createdCurse);

        return response;
    }

    public CourseResponseDto GetCourseById(Guid id)
    {
        var existingCourseEntity = _courseRepository.GetById(id);
        var response = (CourseResponseDto)AutoMapper.MapEntityToResponseDto(existingCourseEntity);
        return response;
    }

    public IEnumerable<CourseResponseDto?> GetAllCourses()
    {
        return _courseRepository.GetAll()
            .Select(entity => AutoMapper.MapEntityToResponseDto(entity) as CourseResponseDto);
    }

    public CourseResponseDto UpdateCourse(Guid id, CourseRequestDto updateRequest)
    {
        var existingCourse = _courseRepository.GetById(id);
        existingCourse.Title = updateRequest.Title;
        existingCourse.Color = updateRequest.Color;
        existingCourse.EnrollType = updateRequest.EnrollType;
        existingCourse.Image = updateRequest.ImagePath;

        var updatedCourse = _courseRepository.Update(id, existingCourse);
        var response = (CourseResponseDto)AutoMapper.MapEntityToResponseDto(updatedCourse);

        return response;
    }

    public void RemoveCourseById(Guid id) => _courseRepository.DeleteById(id);
}