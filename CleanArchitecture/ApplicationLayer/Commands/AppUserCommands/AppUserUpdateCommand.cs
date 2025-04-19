using ApplicationLayer.Common;
using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Commands.AppUserCommands
{
   public class AppUserUpdateCommand : IRequest<ServiceResult>
    {
        public AppUser Entity { get; set; }
    }
}
