 
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.CompanyQueries
{
    public class CompanyGetAllQuery: IRequest<IEnumerable<Company>> 
    {
    }
}