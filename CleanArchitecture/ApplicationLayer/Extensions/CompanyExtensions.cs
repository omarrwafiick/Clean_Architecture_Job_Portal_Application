 
using ApplicationLayer.Dtos;
using DomainLayer.Models;
using System.Xml.Linq;

namespace ApplicationLayer.Extensions
{
    public static class CompanyExtensions
    {
        public static Company MapCompanyDtoToDomain(this CreateCompanyDto dto)
        {
            return new Company
            {
                Name = dto.Name,
                Description = dto.Description,
                Website = dto.Website,
            };
        }

        public static GetCompanyDto MapCompanyDomainToDto(this Company domain)
        {
            return new GetCompanyDto
            (
                domain.Id,
                domain.Name,
                domain.Description,
                domain.Website
            );
        } 

        public static GetCompanyDtoWithPosts MapCompanyDomainToDtoWithPosts(this Company domain)
        {
            return new GetCompanyDtoWithPosts
            (
                domain.Id,
                domain.Name,
                domain.Description,
                domain.Website,
                domain.JobPosts.Select(x=>x.MapJopPostDomainToDto())
            );
        }

        public static GetCompanyDtoWithEmployees MapCompanyDomainToDtoWithEmployees(this Company domain)
        {
            return new GetCompanyDtoWithEmployees
            (
                domain.Id,
                domain.Name,
                domain.Description,
                domain.Website,
                domain.Employees.Select(x => x.MapAppUserDomainToDtoForCompany())
            );
        }

        public static Company MapUpdateCompanyDtoToDomain(this UpdateCompanyDto dto, Company domain)
        {
            domain.Name = dto.Name;
            domain.Website = dto.Website;
            domain.Description = dto.Description;
            return domain;
        }
    }
}  