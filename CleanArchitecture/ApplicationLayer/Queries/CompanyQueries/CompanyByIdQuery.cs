using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Queries.CompanyQueries
{
    public class CompanyByIdQuery : IRequest<Company>  
    {
        public Guid Id { get; set; }
    }
}
