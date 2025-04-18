using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Queries.CompanyQueries
{
    public class GetCompanyEmployeesQuery : IRequest<Company>
    {
        public Guid Id { get; set; }
    }
}
