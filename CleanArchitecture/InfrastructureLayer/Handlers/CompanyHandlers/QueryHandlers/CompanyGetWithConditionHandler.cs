using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.CompanyQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.CompanyHandlers.QueryHandlers
{
    public class CompanyGetWithConditionHandler : IRequestHandler<CompanyGetWithConditionQuery, Company>
    {

        private readonly IGetRepository<Company> _repository;
        public CompanyGetWithConditionHandler(IGetRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(CompanyGetWithConditionQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.condition);
    }
}

