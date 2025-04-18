
using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.CompanyQueries;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.CompanyHandlers.QueryHandlers
{
    public class GetCompanyPostsHandler : IRequestHandler<GetCompanyPostsQuery, Company>
    {
        private readonly IGetRepository<Company> _repository;
        public GetCompanyPostsHandler(IGetRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(GetCompanyPostsQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id, x => x.JobPosts);
    }
}
