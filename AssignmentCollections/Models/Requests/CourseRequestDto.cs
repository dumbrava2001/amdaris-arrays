using AssignmentCollections.Enums;

namespace AssignmentCollections.Models.Requests;

public record CourseRequestDto(string Title, string ImagePath, string Color, EnrollType EnrollType);