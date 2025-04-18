using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.JobPostQueries;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.JobPostHandlers.QueryHandlers
{
    public class GetCompanyJobPostsHandler : IRequestHandler<GetCompanyJobPostsQuery, IEnumerable<JobPost>>
    {
        private readonly IGetAllRepository<JobPost> _repository;
        public GetCompanyJobPostsHandler(IGetAllRepository<JobPost> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JobPost>> Handle(GetCompanyJobPostsQuery request, CancellationToken cancellationToken)
        => await _repository.GetAll(x=>x.CompanyId == request.Id);
    }
}
