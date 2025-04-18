
using ApplicationLayer.Commands.CompanyCommands;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.CompanyHandlers.CommandHandlers
{
    public class RemoveEmployeeFromCompanyHandler : IRequestHandler<RemoveEmployeeFromCompanyCommand, ServiceResult>
    {
        private readonly IGetRepository<AppUser> _getUserrepository;
        private readonly IUpdateRepository<AppUser> _updateUserrepository;
        public RemoveEmployeeFromCompanyHandler(IGetRepository<AppUser> getUserrepository, IUpdateRepository<AppUser> updateUserrepository)
        {
            _getUserrepository = getUserrepository;
            _updateUserrepository = updateUserrepository;
        }
        public async Task<ServiceResult> Handle(RemoveEmployeeFromCompanyCommand request, CancellationToken cancellationToken)
        {
            var employee = await _getUserrepository.Get(request.EmployeeId);
            if(employee is null || employee.CompanyId is null)
            {
                return ServiceResult.Failure("Employee was not found or he is not added to company");
            }
            employee.CompanyId = null;
            var result = await _updateUserrepository.UpdateAsync(employee);
            return result ? ServiceResult.Success("Employee was removed from company successfully") 
                            : ServiceResult.Failure("Failed to remove employee from company");
        }
    }
}
