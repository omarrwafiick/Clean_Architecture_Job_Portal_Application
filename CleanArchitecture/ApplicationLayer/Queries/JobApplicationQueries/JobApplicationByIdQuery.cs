using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Queries.JobApplicationQueries
{
    public class JobApplicationByIdQuery : IRequest<JobApplication>  
    {
        public Guid Id { get; set; }
    }
}
