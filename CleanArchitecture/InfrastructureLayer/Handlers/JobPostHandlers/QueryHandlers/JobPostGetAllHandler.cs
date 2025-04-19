using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.JobPostQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobPostHandlers.QueryHandlers
{
    public class JobPostGetAllHandler: IRequestHandler<JobPostGetAllQuery, IEnumerable<JobPost>>  
    {

        private readonly IGetAllRepository<JobPost> _repository;
        public JobPostGetAllHandler(IGetAllRepository<JobPost> repository)
        {
            _repository = repository;
        }  

        public async Task<IEnumerable<JobPost>> Handle(JobPostGetAllQuery request, CancellationToken cancellationToken)
        => await _repository.GetAll();
    }
}
