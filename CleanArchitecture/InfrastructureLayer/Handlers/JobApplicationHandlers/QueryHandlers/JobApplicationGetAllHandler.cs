using ApplicationLayer.Interfaces; 
using ApplicationLayer.QueriesJobApplicationQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobApplicationHandlers.Query
{
    public class JobApplicationGetAllHandler : IRequestHandler<JobApplicationGetAllQuery, IEnumerable<JobApplication>>  
    {

        private readonly IGetAllRepository<JobApplication> _repository;
        public JobApplicationGetAllHandler(IGetAllRepository<JobApplication> repository)
        {
            _repository = repository;
        }  

        public async Task<IEnumerable<JobApplication>> Handle(JobApplicationGetAllQuery request, CancellationToken cancellationToken)
        => await _repository.GetAll();
    }
}
