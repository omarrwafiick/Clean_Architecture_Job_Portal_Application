using ApplicationLayer.Interfaces; 
using ApplicationLayer.Queries.JobApplicationQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobApplicationHandlers.Query
{
    public class JobApplicationByIdHandler: IRequestHandler<JobApplicationByIdQuery, JobApplication>  
    {

        private readonly IGetRepository<JobApplication> _repository;
        public JobApplicationByIdHandler(IGetRepository<JobApplication> repository)
        {
            _repository = repository;
        }

        public async Task<JobApplication> Handle(JobApplicationByIdQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id);
    }
}
