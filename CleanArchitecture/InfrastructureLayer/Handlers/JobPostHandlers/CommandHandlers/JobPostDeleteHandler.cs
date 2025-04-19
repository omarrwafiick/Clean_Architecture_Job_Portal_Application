
using ApplicationLayer.Commands.JobPostCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.JobPostHandlers.CommandHandlers
{
    public class JobPostDeleteHandler : IRequestHandler<JobPostDeleteCommand, ServiceResult> 
    {
        private readonly IDeleteRepository<JobPost> _deleteRepository; 
        public JobPostDeleteHandler(IDeleteRepository<JobPost> deleteRepository)
        {
            _deleteRepository = deleteRepository; 
        }

        public async Task<ServiceResult> Handle(JobPostDeleteCommand request, CancellationToken cancellationToken)
        {  
            var result = await _deleteRepository.DeleteAsync(request.Id);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
