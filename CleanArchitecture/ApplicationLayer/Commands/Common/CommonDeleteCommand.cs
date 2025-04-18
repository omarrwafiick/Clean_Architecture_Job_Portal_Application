using ApplicationLayer.Common;
using MediatR;

namespace ApplicationLayer.Commands.Common
{
    public class CommonDeleteCommand<T> : IRequest<ServiceResult>
    {
        public Guid Id { get; set; }
    }
}
