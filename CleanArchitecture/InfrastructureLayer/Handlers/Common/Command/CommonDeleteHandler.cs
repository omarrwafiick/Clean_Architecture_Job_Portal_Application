
using ApplicationLayer.Commands.Common;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using MediatR;

namespace InfrastructureLayer.Handlers.Common.Command
{
    public class CommonDeleteHandler<T> : IRequestHandler<CommonDeleteCommand<T>, ServiceResult> where T : class, IBaseEntity
    {
        private readonly IDeleteRepository<T> _deleteRepository; 
        public CommonDeleteHandler(IDeleteRepository<T> deleteRepository)
        {
            _deleteRepository = deleteRepository; 
        }

        public async Task<ServiceResult> Handle(CommonDeleteCommand<T> request, CancellationToken cancellationToken)
        {  
            var result = await _deleteRepository.DeleteAsync(request.Id);

            return result ? ServiceResult.Success("Entity was deleted Successfully")
                          : ServiceResult.Failure("Failed to delete entity");
        }
    }
}
