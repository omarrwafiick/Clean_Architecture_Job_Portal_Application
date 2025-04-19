 
using ApplicationLayer.Common;
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Commands.JobPostCommands
{
    public class JobPostCreateCommand : IRequest<ServiceResult>
    {
        public JobPost Entity { get; set; } 
    }
}