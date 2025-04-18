using ApplicationLayer.Interfaces;
using MediatR;

namespace ApplicationLayer.Queries.Common
{
    public class CommonGetAllQuery<T> : IRequest<IEnumerable<T>> where T : class, IBaseEntity
    {
    }
}