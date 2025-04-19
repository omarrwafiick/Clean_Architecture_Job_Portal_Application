using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.CompanyQueries;
using DomainLayer.Models;
using MediatR;
namespace InfrastructureLayer.Handlers.CompanyHandlers.QueryHandlers
{
    public class GetCompanyEmployeesHandler : IRequestHandler<GetCompanyEmployeesQuery, Company>
    {
        private readonly IGetRepository<Company> _repository;
        public GetCompanyEmployeesHandler(IGetRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(GetCompanyEmployeesQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id, x => x.Employees);
    }
}
