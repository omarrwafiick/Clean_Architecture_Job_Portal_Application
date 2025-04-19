using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.JobApplicationCommands
{
    public class JobApplicationDeleteCommand : IRequest<ServiceResult>
    {
        public Guid Id { get; set; }
    }
}
