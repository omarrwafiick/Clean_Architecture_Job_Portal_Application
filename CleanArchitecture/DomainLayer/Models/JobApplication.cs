using ApplicationLayer.Interfaces;

namespace DomainLayer.Models
{
    public class JobApplication : IBaseEntity
    {
        public Guid Id { get; set; }
        public string ResumeUrl { get; set; }
        public string CoverLetter { get; set; }
        public DateTime AppliedOn { get; set; } = DateTime.UtcNow;
        public Guid JobPostId { get; set; }
        public JobPost JobPost { get; set; }  
        public Guid CandidateId { get; set; }
        public AppUser Candidate { get; set; }  
        public Guid ApplicationStatusId { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
