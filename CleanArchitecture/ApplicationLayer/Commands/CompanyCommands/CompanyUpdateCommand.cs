using ApplicationLayer.Common;
using DomainLayer.Models;
using MediatR; 

namespace ApplicationLayer.Commands.CompanyCommands
{
   public class CompanyUpdateCommand: IRequest<ServiceResult>
    {
        public Company Entity { get; set; }
    }
}
