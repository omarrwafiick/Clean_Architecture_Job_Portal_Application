
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos
{
    public record GetAppUserDto(Guid Id, string FullName, string Email, Guid RoleId, IEnumerable<GetJopPostDto>? userJobPosts, IEnumerable<GetJobApplicationDto>? userJobApplications);
    public record GetAppUserForCompanyDto(Guid Id, string FullName, string Email, Guid RoleId);
    public record CreateAppUserDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [MinLength(12)]
        public string Password { get; init; }

        [MaxLength(500)]
        public string Description { get; init; }

        [Required]
        public Guid RoleId { get; init; }
        
    };
    public record LoginAppUserDto
    {  
        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required] 
        public string Password { get; init; } 
    };
    public record UpdateAppUserDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; init; } 
    };
}
