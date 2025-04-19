using ApplicationLayer.Interfaces;
using ApplicationLayer.Queries.AppUsers;
using DomainLayer.Models;
using MediatR; 

namespace InfrastructureLayer.Handlers.AppUserHandlers.QueryHandlers
{
    public class AppUserGetAllWithIncludeHandler : IRequestHandler<AppUserGetAllWithIncludeQuery, IEnumerable<AppUser>> 
    {

        private readonly IGetAllRepository<AppUser> _repository;
        public AppUserGetAllWithIncludeHandler(IGetAllRepository<AppUser> repository)
        {
            _repository = repository;
        }  

        public async Task<IEnumerable<AppUser>> Handle(AppUserGetAllWithIncludeQuery request, CancellationToken cancellationToken)
        => await _repository.GetAll(x => x.Applications, x => x.JobPosts);
    }
}
