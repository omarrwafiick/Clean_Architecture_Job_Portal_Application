using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.AppUserCommands
{
    public class AppUserDeleteCommand : IRequest<ServiceResult>
    {
        public Guid Id { get; set; }
    }
}
