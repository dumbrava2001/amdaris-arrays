namespace AssignmentCollections.Entities
{
    public class CourseModuleEntity : BaseEntity
    {
        public string Title { get; set; }
        public int OrderNumber { get; set; }
        public CourseEntity Course { get; set; }
        public string Description { get; set; }
    }
}