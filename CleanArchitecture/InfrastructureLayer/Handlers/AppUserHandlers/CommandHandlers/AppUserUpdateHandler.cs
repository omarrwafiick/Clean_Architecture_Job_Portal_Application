
using ApplicationLayer.Commands.AppUserCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.AppUserHandlers.CommandHandlers
{
    public class AppUserUpdateHandler : IRequestHandler<AppUserUpdateCommand, ServiceResult> 
    {
        private readonly IUpdateRepository<AppUser> _updateRepository;
        public AppUserUpdateHandler(IUpdateRepository<AppUser> updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public async Task<ServiceResult> Handle(AppUserUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _updateRepository.UpdateAsync(request.Entity);

            return result ? ServiceResult.Success("Entity was updated Successfully")
                          : ServiceResult.Failure("Failed to update entity");
        }
    }
}
