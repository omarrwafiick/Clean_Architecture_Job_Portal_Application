using ApplicationLayer.Commands.CompanyCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;
namespace InfrastructureLayer.Handlers.CompanyHandlers.CommandHandlers
{
    public class AddEmployeeToCompanyHandler : IRequestHandler<AddEmployeeToCompanyCommand, ServiceResult>
    {
        private readonly IUpdateRepository<AppUser> _updateUserRepository;
        private readonly IGetRepository<AppUser> _getUserRepository;
        private readonly IGetRepository<Company> _getCompanyRepository;
        public AddEmployeeToCompanyHandler(
            IUpdateRepository<AppUser> updateUserRepository, 
            IGetRepository<AppUser> getUserRepository,
            IGetRepository<Company> getCompanyRepository
        )
        {
            _updateUserRepository = updateUserRepository;
            _getUserRepository = getUserRepository;
            _getCompanyRepository = getCompanyRepository;
        }
        public async Task<ServiceResult> Handle(AddEmployeeToCompanyCommand request, CancellationToken cancellationToken)
        {
            var user = await _getUserRepository.Get(request.EmployeeId);
            if(user is null || user.CompanyId is not null)
                return ServiceResult.Failure("Employee is addded to a company already or was not found");
            
            var company = await _getCompanyRepository.Get(request.CompanyId);
            if (company is null)
                return ServiceResult.Failure("Company was not found with this id");

            user.CompanyId = request.CompanyId;
            var result = await _updateUserRepository.UpdateAsync(user);
            return result ? ServiceResult.Success("Employee was added to company successfully") 
                          : ServiceResult.Failure("Failed to add employee to company");
        }
    }
}
