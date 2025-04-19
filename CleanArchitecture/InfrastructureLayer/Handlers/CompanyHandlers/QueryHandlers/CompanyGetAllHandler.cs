using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.CompanyQueries;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.CompanyHandlers.QueryHandlers
{
    public class CompanyGetAllHandler : IRequestHandler<CompanyGetAllQuery, IEnumerable<Company>> 
    {

        private readonly IGetAllRepository<Company> _repository;
        public CompanyGetAllHandler(IGetAllRepository<Company> repository)
        {
            _repository = repository;
        }  

        public async Task<IEnumerable<Company>> Handle(CompanyGetAllQuery request, CancellationToken cancellationToken)
        => await _repository.GetAll();
    }
}
