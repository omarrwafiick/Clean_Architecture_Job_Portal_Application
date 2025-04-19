using ApplicationLayer.Commands.JobApplicationCommands;
using ApplicationLayer.Dtos;
using ApplicationLayer.Extensions;
using ApplicationLayer.Queries.JobApplicationQueries;
using ApplicationLayer.QueriesJobApplicationQueries; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var applications = await _mediator.Send(new JobApplicationGetAllQuery());
            return applications.Any() ? Ok(applications.Select(x => x.MapJobApplicatioDomainToDto())) : NotFound("No application was found");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var application = await _mediator.Send(new JobApplicationByIdQuery { Id = id });
            return application is not null ? Ok(application.MapJobApplicatioDomainToDto()) : NotFound("No application was found");
        }

        [HttpGet("jobpost/{jobPostId:guid}")]
        public async Task<ActionResult> GetByJobPostIdAsync([FromRoute] Guid jobPostId)
        {
            var applications = await _mediator.Send(new JobApplicationGetWithConditionQuery { condition = x => x.JobPostId == jobPostId });
            return applications is not null ? Ok(applications.MapJobApplicatioDomainToDto()) : NotFound("No application was found");
        }

        [HttpPost]
        public async Task<ActionResult> ApplyAsync([FromBody] CreateJobApplicationDto data)
        {
            var isExists = await _mediator.Send(new JobApplicationGetWithConditionQuery
            {
                condition = x =>
                x.AppliedOn <= DateTime.UtcNow.AddDays(7) && x.CandidateId == data.CandidateId
            });
            if (isExists is not null) return BadRequest($"Application is already exists to this user with id {data.CandidateId}");
            var newApplication = await _mediator.Send(new JobApplicationCreateCommand { Entity = data.MapCreateJopApplicationDtoToDomain() });
            return newApplication.SuccessOrNot ? Ok(newApplication.Message) : BadRequest(newApplication.Message);
        }

        [HttpPut("{id:guid}/{companyid:guid}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromRoute] Guid companyid ,[FromBody] UpdateJobApplicationDto data)
        {
            var exists = await _mediator.Send(new JobApplicationByIdQuery { Id = id });
            if (exists is null) return NotFound("Company was not found");
            var updatedApplication = await _mediator.Send(new JobApplicationUpdateCommand { CompanyId = companyid, Entity = data.MapUpdateJopApplicationDtoToDomain(exists) });
            return updatedApplication.SuccessOrNot ? Ok(updatedApplication.Message) : BadRequest(updatedApplication.Message);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var application = await _mediator.Send(new JobApplicationDeleteCommand { Id = id });
            return application.SuccessOrNot ? Ok(application.Message) : BadRequest(application.Message);
        }
    }
}
