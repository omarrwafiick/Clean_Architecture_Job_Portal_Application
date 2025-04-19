
using ApplicationLayer.Commands.JobApplicationCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.JobApplicationHandlers.CommandHandlers
{
    public class JobApplicationCreateCommandHandler: IRequestHandler<JobApplicationCreateCommand, ServiceResult>  
    {
        private readonly ICreateRepository<JobApplication> _repository;

        public JobApplicationCreateCommandHandler(ICreateRepository<JobApplication> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Handle(JobApplicationCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;

            var result = await _repository.CreateAsync(entity);

            return result ? ServiceResult.Success("New entity was created Successfully")
                          : ServiceResult.Failure("Failed to create new entity");
        }
    }
}
