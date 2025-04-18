using ApplicationLayer.Dtos;
using MediatR;

namespace ApplicationLayer.Queries.AppUsers
{
    public class AppUserByCredintialsQuery: IRequest<bool> 
    {
        public LoginAppUserDto LoginAppUserDto { get; set; } 
    }
}
