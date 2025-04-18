using ApplicationLayer.Commands.Common;
using ApplicationLayer.Dtos;
using ApplicationLayer.Extensions;
using ApplicationLayer.Queries.Common;
using DomainLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {  
            var applications = await _mediator.Send(new CommonGetAllQuery<JobApplication>());
            return applications.Any() ? Ok(applications.Select(x => x.MapJobApplicatioDomainToDto())) : NotFound("No application was found");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var application = await _mediator.Send(new CommonByIdQuery<JobApplication> { Id = id });
            return application is not null ? Ok(application.MapJobApplicatioDomainToDto()) : NotFound("No application was found");
        } 

        [HttpGet("{jobPostId:guid}")]
        public async Task<ActionResult> GetByJobPostIdAsync([FromRoute] Guid jobPostId)
        {
            var applications = await _mediator.Send(new CommonGetWithConditionQuery<JobApplication> { condition = x => x.JobPostId == jobPostId });
            return applications is not null ? Ok(applications.MapJobApplicatioDomainToDto) : NotFound("No application was found");
        }

        [HttpPost]
        public async Task<ActionResult> ApplyAsync([FromBody] CreateJobApplicationDto data)
        {
            var isExists = await _mediator.Send(new CommonGetWithConditionQuery<JobApplication> { condition = x => 
            x.AppliedOn <= DateTime.UtcNow.AddDays(7) && x.CandidateId == data.CandidateId});
            if (isExists is not null) return BadRequest($"Application is already exists to this user with id {data.CandidateId}");
            var newApplication = await _mediator.Send(new CommonCreateCommand<JobApplication> { Entity = data.MapCreateJopApplicationDtoToDomain() });
            return newApplication.SuccessOrNot ? Ok(newApplication.Message) : BadRequest(newApplication.Message);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateJobApplicationDto data)
        {
            var exists = await _mediator.Send(new CommonByIdQuery<JobApplication> { Id = id });
            if (exists is null) return NotFound("Company was not found");
            var updatedApplication = await _mediator.Send(new CommonUpdateCommand<JobApplication> { Entity = data.MapUpdateJopApplicationDtoToDomain(exists) });
            return updatedApplication.SuccessOrNot ? Ok(updatedApplication.Message) : BadRequest(updatedApplication.Message);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var application = await _mediator.Send(new CommonDeleteCommand<JobApplication> { Id = id });
            return application.SuccessOrNot ? Ok(application.Message) : BadRequest(application.Message);
        }
    }
}
