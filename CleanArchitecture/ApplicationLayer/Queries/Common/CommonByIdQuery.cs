using MediatR; 

namespace ApplicationLayer.Queries.Common
{
    public class CommonByIdQuery<T> : IRequest<T> where T : class
    {
        public Guid Id { get; set; }
    }
}
