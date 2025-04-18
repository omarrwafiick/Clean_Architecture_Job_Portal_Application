 
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.CompanyQueries
{
    public class GetCompanyPostsQuery : IRequest<Company>
    {
        public Guid Id { get; set; }
    }
}
