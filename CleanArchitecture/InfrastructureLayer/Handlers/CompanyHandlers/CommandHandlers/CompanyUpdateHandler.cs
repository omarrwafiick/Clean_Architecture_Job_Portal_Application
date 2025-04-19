using ApplicationLayer.Commands.CompanyCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.CompanyHandlers.CommandHandlers
{
    public class CompanyUpdateHandler : IRequestHandler<CompanyUpdateCommand, ServiceResult> 
    {
        private readonly IUpdateRepository<Company> _updateRepository;
        public CompanyUpdateHandler(IUpdateRepository<Company> updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public async Task<ServiceResult> Handle(CompanyUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _updateRepository.UpdateAsync(request.Entity);

            return result ? ServiceResult.Success("Entity was updated Successfully")
                          : ServiceResult.Failure("Failed to update entity");
        }
    }
}
