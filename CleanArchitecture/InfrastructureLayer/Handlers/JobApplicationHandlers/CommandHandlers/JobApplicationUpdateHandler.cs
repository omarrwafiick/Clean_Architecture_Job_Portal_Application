
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
        private readonly IGetRepository<ApplicationStatus> _applicationStatusRepository;
        private readonly IGetRepository<AppUser> _getAppUserRepository;
        private readonly IUpdateRepository<AppUser> _updateAppUserRepository;
        public JobApplicationUpdateHandler(
            IUpdateRepository<JobApplication> updateRepository, 
            IGetRepository<ApplicationStatus> applicationStatusRepository,
            IGetRepository<AppUser> getAppUserRepository,
            IUpdateRepository<AppUser> updateAppUserRepository)
        {
            _updateRepository = updateRepository;
            _applicationStatusRepository = applicationStatusRepository;
            _getAppUserRepository = getAppUserRepository;
            _updateAppUserRepository = updateAppUserRepository;
        }

        public async Task<ServiceResult> Handle(JobApplicationUpdateCommand request, CancellationToken cancellationToken)
        {
            var applicationStatus = await _applicationStatusRepository.Get(request.Entity.ApplicationStatusId);

            if (applicationStatus == null) { 
                return ServiceResult.Failure("Failed to update entity");
            }
            if(applicationStatus.Name == "Hired")
            {
                var user = await _getAppUserRepository.Get(request.Entity.CandidateId);
                if (user == null) {
                    return ServiceResult.Failure("Failed to update entity because user was not found");
                }
                user.CompanyId = request.CompanyId;
                await _updateAppUserRepository.UpdateAsync(user);
            }
            var result = await _updateRepository.UpdateAsync(request.Entity);

            return result ? ServiceResult.Success("Entity was updated Successfully")
                          : ServiceResult.Failure("Failed to update entity");
        }
    }
}
