using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Queries.AppUsers
{
    public class AppUserByIdWithIncludeQuery : IRequest<AppUser> 
    {
        public Guid Id { get; set; }
    }
}
