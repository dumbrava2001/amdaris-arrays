using AssignmentCollections.Enums;

namespace AssignmentCollections.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public UserProfileEntity Profile { get; set; }
    }
}