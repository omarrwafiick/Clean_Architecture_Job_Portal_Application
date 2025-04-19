
using ApplicationLayer.Commands.JobPostCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.JobPostHandlers.CommandHandlers
{
    public class JobPostCreateCommandHandler: IRequestHandler<JobPostCreateCommand, ServiceResult> 
    {
        private readonly ICreateRepository<JobPost> _repository;

        public JobPostCreateCommandHandler(ICreateRepository<JobPost> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Handle(JobPostCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;

            var result = await _repository.CreateAsync(entity);

            return result ? ServiceResult.Success("New entity was created Successfully")
                          : ServiceResult.Failure("Failed to create new entity");
        }
    }
}
