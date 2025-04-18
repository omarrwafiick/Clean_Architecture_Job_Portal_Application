
using ApplicationLayer.Interfaces;

namespace DomainLayer.Models
{ 
    public class Company : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  
        public string Website { get; set; } 
        public string Description { get; set; } 
        public List<AppUser> Employees { get; set; }
        public List<JobPost> JobPosts { get; set; }
    }
}
