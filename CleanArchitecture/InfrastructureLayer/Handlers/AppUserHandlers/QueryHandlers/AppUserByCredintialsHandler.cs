using ApplicationLayer.Common;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;

namespace InfrastructureLayer.Handlers.AppUserHandlers.QueryHandlers
{
    public class AppUserByCredintialsHandler : IRequestHandler<ApplicationLayer.Queries.AppUsers.AppUserByCredintialsQuery, bool>
    {

        private readonly IGetRepository<AppUser> _repository;
        public AppUserByCredintialsHandler(IGetRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ApplicationLayer.Queries.AppUsers.AppUserByCredintialsQuery request, CancellationToken cancellationToken)
        {
            var hashedPassword = UserSecurityService.HashPassword(request.LoginAppUserDto.Password);
            var user = await _repository.Get(x => x.Email == request.LoginAppUserDto.Email);
            return UserSecurityService.VerifyPassword(hashedPassword, user.Password);
        }
    }
}
