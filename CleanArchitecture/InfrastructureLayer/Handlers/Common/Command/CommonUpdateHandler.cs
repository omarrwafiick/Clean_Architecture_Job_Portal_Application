using ApplicationLayer.Commands.Common;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using MediatR; 

namespace InfrastructureLayer.Handlers.Common.Command
{
    internal class CommonUpdateHandler<T> : IRequestHandler<CommonUpdateCommand<T>, ServiceResult> where T : class, IBaseEntity
    {
        private readonly IUpdateRepository<T> _updateRepository;
        public CommonUpdateHandler(IUpdateRepository<T> updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public async Task<ServiceResult> Handle(CommonUpdateCommand<T> request, CancellationToken cancellationToken)
        {
            var result = await _updateRepository.UpdateAsync(request.Entity);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
