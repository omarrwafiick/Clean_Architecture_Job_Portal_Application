using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Queries.AppUsers
{
    public class AppUserByEmailQuery : IRequest<AppUser>  
    {
        public string Email { get; set; }
    }
}
