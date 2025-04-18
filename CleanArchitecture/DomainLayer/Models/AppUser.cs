using ApplicationLayer.Interfaces;

namespace DomainLayer.Models
{
    public class AppUser : IBaseEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<JobApplication> Applications { get; set; } 
        public List<JobPost> JobPosts { get; set; } 
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
