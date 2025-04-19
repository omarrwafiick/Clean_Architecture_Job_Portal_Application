
using ApplicationLayer.Commands.JobApplicationCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.JobApplicationHandlers.CommandHandlers
{
    public class JobApplicationDeleteHandler: IRequestHandler<JobApplicationDeleteCommand, ServiceResult> 
    {
        private readonly IDeleteRepository<JobApplication> _deleteRepository; 
        public JobApplicationDeleteHandler(IDeleteRepository<JobApplication> deleteRepository)
        {
            _deleteRepository = deleteRepository; 
        }

        public async Task<ServiceResult> Handle(JobApplicationDeleteCommand request, CancellationToken cancellationToken)
        {  
            var result = await _deleteRepository.DeleteAsync(request.Id);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
