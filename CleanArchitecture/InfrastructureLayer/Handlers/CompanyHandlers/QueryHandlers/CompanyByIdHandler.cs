using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.CompanyQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.CompanyHandlers.QueryHandlers
{
    public class CompanyByIdHandler: IRequestHandler<CompanyByIdQuery, Company>  
    {

        private readonly IGetRepository<Company> _repository;
        public CompanyByIdHandler(IGetRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(CompanyByIdQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id);
    }
}
