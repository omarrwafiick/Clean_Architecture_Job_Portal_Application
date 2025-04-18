 
using ApplicationLayer.Dtos;
using DomainLayer.Models;

namespace ApplicationLayer.Extensions
{
    public static class JobApplicationExtensions
    { 
        public static GetJobApplicationDto MapJobApplicatioDomainToDto(this JobApplication domain)
        {
            return new GetJobApplicationDto
            (
               domain.Id,
               domain.JobPostId,
               domain.CandidateId,
               domain.ResumeUrl,
               domain.CoverLetter,
               domain.ApplicationStatusId,
               domain.AppliedOn
            );
        }

        public static JobApplication MapCreateJopApplicationDtoToDomain(this CreateJobApplicationDto dto)
        {
            return new JobApplication
            { 
                ResumeUrl = dto.ResumeUrl,
                CoverLetter = dto.CoverLetter,
                JobPostId = dto.JobPostId,
                CandidateId = dto.CandidateId,
                ApplicationStatusId = dto.ApplicationStatusId
            };
        }

        public static JobApplication MapUpdateJopApplicationDtoToDomain(this UpdateJobApplicationDto dto, JobApplication domain)
        {
            domain.ResumeUrl = dto.ResumeUrl;
            domain.CoverLetter = dto.CoverLetter;
            domain.JobPostId = dto.JobPostId; 
            domain.ApplicationStatusId = dto.ApplicationStatusId;
            return domain;
        }
    }
}
