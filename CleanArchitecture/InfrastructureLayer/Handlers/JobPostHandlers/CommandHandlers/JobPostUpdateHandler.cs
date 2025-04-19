
using ApplicationLayer.Commands.JobPostCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobPostHandlers.CommandHandlers
{
    public class JobPostUpdateHandler: IRequestHandler<JobPostUpdateCommand, ServiceResult>  
    {
        private readonly IUpdateRepository<JobPost> _updateRepository;
        public JobPostUpdateHandler(IUpdateRepository<JobPost> updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public async Task<ServiceResult> Handle(JobPostUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _updateRepository.UpdateAsync(request.Entity);

            return result ? ServiceResult.Success("Entity was updated Successfully")
                          : ServiceResult.Failure("Failed to update entity");
        }
    }
}
