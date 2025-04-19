
using ApplicationLayer.Commands.CompanyCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.CompanyHandlers.CommandHandlers
{
    public class CompanyCreateCommandHandler : IRequestHandler<CompanyCreateCommand, ServiceResult> 
    {
        private readonly ICreateRepository<Company> _repository;

        public CompanyCreateCommandHandler(ICreateRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;

            var result = await _repository.CreateAsync(entity);

            return result ? ServiceResult.Success("New entity was created Successfully")
                          : ServiceResult.Failure("Failed to create new entity");
        }
    }
}
