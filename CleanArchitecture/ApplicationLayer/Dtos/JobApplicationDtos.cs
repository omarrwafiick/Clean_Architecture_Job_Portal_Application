

using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos
{
    public record GetJobApplicationDto(Guid Id, Guid JobPostId, Guid CandidateId, string ResumeUrl, string CoverLetter, Guid ApplicationStatusId, DateTime AppliedOn);
    public record CreateJobApplicationDto
    {
        [Required]
        public Guid JobPostId { get; init; }

        [Required]
        public Guid CandidateId { get; init; }

        [Required]
        [Url]
        public string ResumeUrl { get; init; }

        public string CoverLetter { get; init; }

        [Required]
        public Guid ApplicationStatusId { get; init; }
         
    } 
    public record UpdateJobApplicationDto
    {
        [Required]
        public Guid JobPostId { get; init; } 

        [Required]
        [Url]
        public string ResumeUrl { get; init; }

        public string CoverLetter { get; init; }

        [Required]
        public Guid ApplicationStatusId { get; init; }
          
    }

}
