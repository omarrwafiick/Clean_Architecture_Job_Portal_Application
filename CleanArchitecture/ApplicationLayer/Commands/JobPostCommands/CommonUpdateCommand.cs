using ApplicationLayer.Common;
using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Commands.JobPostCommands
{
   public class JobPostUpdateCommand : IRequest<ServiceResult>
    {
        public JobPost Entity { get; set; }
    }
}
