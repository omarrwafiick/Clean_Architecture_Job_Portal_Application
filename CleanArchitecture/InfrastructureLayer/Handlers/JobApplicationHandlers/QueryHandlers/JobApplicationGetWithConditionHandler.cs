using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.JobApplicationQueries;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.JobApplicationHandlers.Query
{
    public class JobApplicationGetWithConditionHandler: IRequestHandler<JobApplicationGetWithConditionQuery, JobApplication>
    {

        private readonly IGetRepository<JobApplication> _repository;
        public JobApplicationGetWithConditionHandler(IGetRepository<JobApplication> repository)
        {
            _repository = repository;
        }

        public async Task<JobApplication> Handle(JobApplicationGetWithConditionQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.condition);
    }
}
