

using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos
{
    public record GetJopPostDto(Guid Id, string Title, string Description, string Location, decimal SalaryFrom, decimal SalaryTo, Guid JobTypeId, DateTime PostedDate, DateTime ExpirationDate, Guid EmployerId);
    public record CreateJobPostDto
    {
        [Required]
        public string Title { get; init; }

        public string Description { get; init; }

        public string Location { get; init; }

        [Range(0, double.MaxValue)]
        public decimal SalaryFrom { get; init; }

        [Range(0, double.MaxValue)]
        public decimal SalaryTo { get; init; }

        [Required]
        public Guid JobTypeId { get; init; }

        public DateTime PostedDate { get; init; }

        public DateTime ExpirationDate { get; init; }

        [Required]
        public Guid EmployerId { get; init; }
         
        public Guid? CompanyId { get; init; }
    } 
    public record UpdateJobPostDto
    {
        [Required]
        public string Title { get; init; }

        public string Description { get; init; }

        public string Location { get; init; }

        [Range(0, double.MaxValue)]
        public decimal SalaryFrom { get; init; }

        [Range(0, double.MaxValue)]
        public decimal SalaryTo { get; init; }

        [Required]
        public Guid JobTypeId { get; init; } 

        public DateTime ExpirationDate { get; init; } 
    }

}
