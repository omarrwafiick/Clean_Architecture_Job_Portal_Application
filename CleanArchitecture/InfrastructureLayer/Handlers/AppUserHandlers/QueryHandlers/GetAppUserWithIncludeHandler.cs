using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.AppUsers;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.AppUserHandlers.QueryHandlers
{
    public class GetAppUserWithIncludeHandler : IRequestHandler<GetAppUserWithIncludeQuery, AppUser>
    {
        private readonly IGetRepository<AppUser> _repository;
        public GetAppUserWithIncludeHandler(IGetRepository<AppUser> repository)
        {
            _repository = repository;
        }
        public async Task<AppUser> Handle(GetAppUserWithIncludeQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id, x => x.Applications);
    }
}
