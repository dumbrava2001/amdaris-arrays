using AssignmentCollections.Enums;

namespace AssignmentCollections.Entities
{
    public class CourseEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public string Password { get; set; }
        public UserEntity Owner { get; set; }
        public string Image { get; set; }
        public EnrollType EnrollType { get; set; }
        public IEnumerable<CourseModuleEntity> ModuleList { get; set; }

        public void CopyTo(CourseEntity entity)
        {
            entity.Id = Id;
            entity.Color = Color;
            entity.Password = Password;
            entity.Owner = Owner;
            entity.Image = Image;
            entity.EnrollType = EnrollType;
            entity.ModuleList = ModuleList;
        }
    }
}