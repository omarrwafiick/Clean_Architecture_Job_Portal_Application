using ApplicationLayer.Commands.AppUserCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.AppUserHandlers.CommandHandlers
{
    public class AppUserDeleteHandler : IRequestHandler<AppUserDeleteCommand, ServiceResult>  
    {
        private readonly IDeleteRepository<AppUser> _deleteRepository; 
        public AppUserDeleteHandler(IDeleteRepository<AppUser> deleteRepository)
        {
            _deleteRepository = deleteRepository; 
        }

        public async Task<ServiceResult> Handle(AppUserDeleteCommand request, CancellationToken cancellationToken)
        {  
            var result = await _deleteRepository.DeleteAsync(request.Id);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
