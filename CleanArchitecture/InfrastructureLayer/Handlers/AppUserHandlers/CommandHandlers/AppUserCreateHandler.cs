
using ApplicationLayer.Commands.AppUserCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.AppUserHandlers.CommandHandlers
{
    public class AppUserCreateCommandHandler : IRequestHandler<AppUserCreateCommand, ServiceResult> 
    {
        private readonly ICreateRepository<AppUser> _repository;

        public AppUserCreateCommandHandler(ICreateRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Handle(AppUserCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;

            var result = await _repository.CreateAsync(entity);

            return result ? ServiceResult.Success("New entity was created Successfully")
                          : ServiceResult.Failure("Failed to create new entity");
        }
    }
}
