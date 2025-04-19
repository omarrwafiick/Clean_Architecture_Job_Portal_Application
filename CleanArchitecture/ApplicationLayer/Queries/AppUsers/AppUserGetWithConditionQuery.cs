using DomainLayer.Models;
using MediatR;
using System.Linq.Expressions;

namespace ApplicationLayer.Queries.AppUsers
{
    public class AppUserGetWithConditionQuery : IRequest<AppUser>  
    {
        public Expression<Func<AppUser, object>> condition {  get; set; }
    }
}
