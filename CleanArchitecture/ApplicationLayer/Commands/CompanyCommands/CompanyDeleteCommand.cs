using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.CompanyCommands
{
    public class CompanyDeleteCommand : IRequest<ServiceResult>
    {
        public Guid Id { get; set; }
    }
}
