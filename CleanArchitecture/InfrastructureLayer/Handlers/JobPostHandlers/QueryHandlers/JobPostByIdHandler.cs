using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.JobPostQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobPostHandlers.QueryHandlers
{
    public class JobPostByIdHandler : IRequestHandler<JobPostByIdQuery, JobPost> 
    {

        private readonly IGetRepository<JobPost> _repository;
        public JobPostByIdHandler(IGetRepository<JobPost> repository)
        {
            _repository = repository;
        }

        public async Task<JobPost> Handle(JobPostByIdQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id);
    }
}
