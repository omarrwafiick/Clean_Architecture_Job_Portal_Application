 
using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.CompanyCommands
{
    public class AddEmployeeToCompanyCommand : IRequest<ServiceResult>
    {
        public Guid EmployeeId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
