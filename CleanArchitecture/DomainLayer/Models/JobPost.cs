using ApplicationLayer.Interfaces;

namespace DomainLayer.Models
{
    public class JobPost : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }  
        public string Location { get; set; }  
        public decimal SalaryFrom { get; set; }
        public decimal SalaryTo { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ExpirationDate { get; set; } 
        public Guid EmployerId { get; set; }
        public AppUser Employer { get; set; }
        public Guid JobTypeId { get; set; }
        public JobType Type { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public List<JobApplication> Applications { get; set; } 
    }
}
