using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.JobPostQueries
{
    public class GetCompanyJobPostsQuery : IRequest<IEnumerable<JobPost>>
    {
        public Guid Id { get; set; }
    }
}
