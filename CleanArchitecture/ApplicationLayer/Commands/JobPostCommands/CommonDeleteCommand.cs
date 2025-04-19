using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.JobPostCommands
{
    public class JobPostDeleteCommand : IRequest<ServiceResult>
    {
        public Guid Id { get; set; }
    }
}
