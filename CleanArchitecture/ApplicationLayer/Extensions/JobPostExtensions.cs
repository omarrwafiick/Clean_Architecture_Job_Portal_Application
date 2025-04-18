 
using ApplicationLayer.Dtos;
using DomainLayer.Models;

namespace ApplicationLayer.Extensions
{
    public static class JobPostExtensions
    {
        public static GetJopPostDto MapJopPostDomainToDto(this JobPost domain)
        {
            return new GetJopPostDto
            (
                domain.Id,
                domain.Title,
                domain.Description,
                domain.Location,
                domain.SalaryFrom,
                domain.SalaryTo,
                domain.JobTypeId,
                domain.PostedDate,
                domain.ExpirationDate,
                domain.EmployerId
            );
        }

        public static JobPost MapCreateJopPostDtoToDomain(this CreateJobPostDto dto)
        {
            return new JobPost
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                SalaryFrom = dto.SalaryFrom,
                SalaryTo = dto.SalaryTo,
                PostedDate = dto.PostedDate,
                ExpirationDate = dto.ExpirationDate,
                EmployerId = dto.EmployerId,
                JobTypeId = dto.JobTypeId,
                CompanyId = dto.CompanyId is not null ? dto.CompanyId : null
            };
        }

        public static JobPost MapUpdateJopPostDtoToDomain(this UpdateJobPostDto dto, JobPost domain)
        {
            domain.Title = dto.Title;
            domain.Description = dto.Description;
            domain.Location = dto.Location;
            domain.SalaryFrom = dto.SalaryFrom;
            domain.SalaryTo = dto.SalaryTo;
            domain.JobTypeId = dto.JobTypeId;
            domain.ExpirationDate = dto.ExpirationDate;
            return domain;
        } 
        
    }
}
