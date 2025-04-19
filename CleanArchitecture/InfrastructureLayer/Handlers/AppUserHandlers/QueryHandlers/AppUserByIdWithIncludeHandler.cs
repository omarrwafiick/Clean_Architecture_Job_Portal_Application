using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.AppUsers;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.AppUserHandlers.QueryHandlers
{ 
    public class AppUserByIdWithIncludeHandler : IRequestHandler<AppUserByIdWithIncludeQuery, AppUser>   
    {

        private readonly IGetRepository<AppUser> _repository;
        public AppUserByIdWithIncludeHandler(IGetRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<AppUser> Handle(AppUserByIdWithIncludeQuery request, CancellationToken cancellationToken)
        => await _repository.Get(request.Id, x => x.Applications, x => x.JobPosts);
    }
}
