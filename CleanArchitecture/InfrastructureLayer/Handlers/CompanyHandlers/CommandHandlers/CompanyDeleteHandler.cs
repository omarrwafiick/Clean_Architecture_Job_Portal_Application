using ApplicationLayer.Commands.CompanyCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.CompanyHandlers.CommandHandlers
{
    public class CompanyDeleteHandler : IRequestHandler<CompanyDeleteCommand, ServiceResult> 
    {
        private readonly IDeleteRepository<Company> _deleteRepository; 
        public CompanyDeleteHandler(IDeleteRepository<Company> deleteRepository)
        {
            _deleteRepository = deleteRepository; 
        }

        public async Task<ServiceResult> Handle(CompanyDeleteCommand request, CancellationToken cancellationToken)
        {  
            var result = await _deleteRepository.DeleteAsync(request.Id);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
