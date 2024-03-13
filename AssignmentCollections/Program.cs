using AssignmentCollections.Entities;
using AssignmentCollections.Enums;
using AssignmentCollections.Models.Requests;
using AssignmentCollections.Repositories;
using AssignmentCollections.Services;

namespace AssignmentCollections;

internal static class Program
{
    public static void Main(string[] args)
    {
        var courseDB = new CourseRequestDto("Database", "/courses/database/primary.png", "#FF0000", EnrollType.PUBLIC);
        var courseOOP = new CourseRequestDto("OOP", "/courses/oop/primary.png", "#00FF00", EnrollType.PRIVATE);
        var courseNet = new CourseRequestDto("C#/.Net", "/courses/c#/net/primary.png", "#AA0000", EnrollType.PUBLIC);
        var courseReact = new CourseRequestDto("React", "/courses/react/primary.png", "#FF0000", EnrollType.PUBLIC);

        IRepository<CourseEntity> courseRepository = new ListCourseRepository();
        var courseService = new CourseService(courseRepository);

        courseService.CreateCourse(courseDB);
        courseService.CreateCourse(courseOOP);
        courseService.CreateCourse(courseNet);
        courseService.CreateCourse(courseReact);
        
        //GET all courses in response format
        var allCourses = courseService.GetAllCourses();
        
        
    }
}