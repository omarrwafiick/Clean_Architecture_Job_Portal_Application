
using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos
{
    public record GetCompanyDto(Guid Id, string Name, string Website, string Description);
    public record GetCompanyDtoWithPosts(Guid Id, string Name, string Website, string Description, IEnumerable<GetJopPostDto> posts);
    public record GetCompanyDtoWithEmployees(Guid Id, string Name, string Website, string Description, IEnumerable<GetAppUserForCompanyDto> employees);
    public record CreateCompanyDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; }

        [Url]
        public string Website { get; init; }

        [MaxLength(500)]
        public string Description { get; init; }
    }
    public record UpdateCompanyDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; }

        [Url]
        public string Website { get; init; }

        [MaxLength(500)]
        public string Description { get; init; }
    }
}
