
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.JobPostQueries
{
    public class GetJobPostsBySearchQuery : IRequest<IEnumerable<JobPost>>
    { 
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal SalaryTo { get; set; } 
        public Guid JobTypeId { get; set; } 
    }
}
