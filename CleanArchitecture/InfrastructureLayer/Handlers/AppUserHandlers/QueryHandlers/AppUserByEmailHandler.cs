using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.AppUsers;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.AppUserHandlers.QueryHandlers
{
    public class AppUserByEmailHandler : IRequestHandler<AppUserByEmailQuery, AppUser>
    {

        private readonly IGetRepository<AppUser> _repository;
        public AppUserByEmailHandler(IGetRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<AppUser> Handle(AppUserByEmailQuery request, CancellationToken cancellationToken)
        => await _repository.Get(x => x.Email == request.Email);
    }
}
