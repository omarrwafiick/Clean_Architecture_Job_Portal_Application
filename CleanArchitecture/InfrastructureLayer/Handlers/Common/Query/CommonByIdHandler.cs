using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.Common; 
using MediatR; 

namespace InfrastructureLayer.Handlers.Common.Query
{
    internal class CommonByIdHandler<T> : IRequestHandler<CommonByIdQuery<T>, T> where T : class, IBaseEntity
    {

        private readonly IGetRepository<T> _repository;
        public CommonByIdHandler(IGetRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(CommonByIdQuery<T> request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id);
    }
}
