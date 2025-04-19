
using ApplicationLayer.Common;
using ApplicationLayer.Dtos;
using DomainLayer.Models;

namespace ApplicationLayer.Extensions
{
    public static class AppUserExtensions
    {
        public static AppUser MapAppUserDtoToDomain(this CreateAppUserDto dto)
        {
            return new AppUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = UserSecurityService.HashPassword( dto.Password),
                RoleId = dto.RoleId
            };
        }

        public static AppUser MapUpdateAppUserDtoToDomain(this AppUser domain, UpdateAppUserDto dto)
        {
            domain.FullName = dto.FullName;
            return domain;
        }

        public static GetAppUserDto MapAppUserDomainToDto(this AppUser domain)
        { 
            return new GetAppUserDto
            (
                domain.Id,
                domain.FullName,
                domain.Email, 
                domain.RoleId,
                domain.JobPosts.Select(x => x.MapJopPostDomainToDto()),
                domain.Applications.Select(x => x.MapJobApplicatioDomainToDto())
            );
        }

        public static GetAppUserForCompanyDto MapAppUserDomainToDtoForCompany(this AppUser domain)
        {
            return new GetAppUserForCompanyDto
            (
                domain.Id,
                domain.FullName,
                domain.Email,
                domain.RoleId
            );
        }
    }
}
