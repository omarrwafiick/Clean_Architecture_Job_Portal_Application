
using ApplicationLayer.Commands.Common;
using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using MediatR;

namespace InfrastructureLayer.Handlers.Common.Command
{
    public class CreateCommandHandler<T> : IRequestHandler<CommonCreateCommand<T>, ServiceResult> where T : class, IBaseEntity
    {
        private readonly ICreateRepository<T> _repository;

        public CreateCommandHandler(ICreateRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Handle(CommonCreateCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;

            var result = await _repository.CreateAsync(entity);

            return result ? ServiceResult.Success("New entity was created Successfully")
                          : ServiceResult.Failure("Failed to create new entity");
        }
    }
}
