using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Queries.JobPostQueries
{
    public class JobPostByIdQuery: IRequest<JobPost> 
    {
        public Guid Id { get; set; }
    }
}
