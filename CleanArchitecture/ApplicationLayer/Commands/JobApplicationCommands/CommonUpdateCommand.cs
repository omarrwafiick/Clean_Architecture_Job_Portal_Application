using ApplicationLayer.Common;
using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Commands.JobApplicationCommands
{
   public class JobApplicationUpdateCommand : IRequest<ServiceResult>
    {
        public JobApplication Entity { get; set; }
    }
}
