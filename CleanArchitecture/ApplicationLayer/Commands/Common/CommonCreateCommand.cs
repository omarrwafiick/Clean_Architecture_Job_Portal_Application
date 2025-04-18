 
using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.Common
{
    public class CommonCreateCommand<T> : IRequest<ServiceResult>
    {
        public T Entity { get; set; } 
    }
}