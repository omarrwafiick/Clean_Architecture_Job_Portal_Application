
using ApplicationLayer.Commands.JobApplicationCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobApplicationHandlers.CommandHandlers
{
    public class JobApplicationUpdateHandler: IRequestHandler<JobApplicationUpdateCommand, ServiceResult> 
    {
        private readonly IUpdateRepository<JobApplication> _updateRepository;
        public JobApplicationUpdateHandler(IUpdateRepository<JobApplication> updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public async Task<ServiceResult> Handle(JobApplicationUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _updateRepository.UpdateAsync(request.Entity);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
