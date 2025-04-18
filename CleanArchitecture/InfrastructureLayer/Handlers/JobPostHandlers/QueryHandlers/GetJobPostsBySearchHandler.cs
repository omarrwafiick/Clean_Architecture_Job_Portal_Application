using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.JobPostQueries;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.JobPostHandlers.QueryHandlers
{
    public class GetJobPostsBySearchHandler : IRequestHandler<GetJobPostsBySearchQuery, IEnumerable<JobPost>>
    {
        private readonly IGetAllRepository<JobPost> _repository;
        public GetJobPostsBySearchHandler(IGetAllRepository<JobPost> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JobPost>> Handle(GetJobPostsBySearchQuery request, CancellationToken cancellationToken)
        => await _repository.GetAll(
            x => x.Description.Contains(request.Description) &&
                 x.Location == request.Location &&
                 x.SalaryTo == request.SalaryTo &&
                 x.JobTypeId == request.JobTypeId
        );
    }
}
