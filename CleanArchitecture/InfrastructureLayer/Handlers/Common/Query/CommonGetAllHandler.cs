using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.Common;
using MediatR; 

namespace InfrastructureLayer.Handlers.Common.Query
{
    public class CommonGetAllHandler<T> : IRequestHandler<CommonGetAllQuery<T>, IEnumerable<T>> where T : class, IBaseEntity
    {

        private readonly IGetAllRepository<T> _repository;
        public CommonGetAllHandler(IGetAllRepository<T> repository)
        {
            _repository = repository;
        }  

        public async Task<IEnumerable<T>> Handle(CommonGetAllQuery<T> request, CancellationToken cancellationToken)
        => await _repository.GetAll();
    }
}
