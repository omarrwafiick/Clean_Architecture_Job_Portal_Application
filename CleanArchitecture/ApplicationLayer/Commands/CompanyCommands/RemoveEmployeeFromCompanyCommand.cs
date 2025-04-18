using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.CompanyCommands
{
    public class RemoveEmployeeFromCompanyCommand : IRequest<ServiceResult>
    {
        public Guid EmployeeId { get; set; }
    }
}
