 
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.AppUsers
{
    public class AppUserGetAllWithIncludeQuery : IRequest<IEnumerable<AppUser>>
    {
    }
}