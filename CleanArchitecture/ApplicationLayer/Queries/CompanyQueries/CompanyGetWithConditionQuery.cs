using DomainLayer.Models;
using MediatR;
using System.Linq.Expressions;

namespace ApplicationLayer.Queries.CompanyQueries
{
    public class CompanyGetWithConditionQuery : IRequest<Company> 
    {
        public Expression<Func<Company, bool>> condition {  get; set; }
    }
}
