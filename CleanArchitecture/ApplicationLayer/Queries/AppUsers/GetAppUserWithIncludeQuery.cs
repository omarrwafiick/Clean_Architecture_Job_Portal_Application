using DomainLayer.Models;
using MediatR; 
namespace ApplicationLayer.Queries.AppUsers
{
    public class GetAppUserWithIncludeQuery : IRequest<AppUser>
    {
        public Guid Id { get; set; } 
    }
}
