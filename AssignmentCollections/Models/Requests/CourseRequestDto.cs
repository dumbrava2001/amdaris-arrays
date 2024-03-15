using AssignmentCollections.Enums;

namespace AssignmentCollections.Models.Requests;

public class CourseRequestDto : IBaseDto

{
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string Color { get; set; }
    public EnrollType EnrollType { get; set; }

    public CourseRequestDto(string Title, string ImagePath, string Color, EnrollType EnrollType)
    {
        this.Title = Title;
        this.ImagePath = ImagePath;
        this.Color = Color;
        this.EnrollType = EnrollType;
    }
}