using ApplicationLayer.Common;
using MediatR; 

namespace ApplicationLayer.Commands.Common
{
   public class CommonUpdateCommand<T> : IRequest<ServiceResult>
    {
        public T Entity { get; set; }
    }
}
