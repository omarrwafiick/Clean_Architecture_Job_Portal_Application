using ApplicationLayer.Commands.Common;
using ApplicationLayer.Dtos;
using ApplicationLayer.Extensions;
using ApplicationLayer.Queries.AppUsers;
using ApplicationLayer.Queries.Common;
using DomainLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace PresentationLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    { 
        private readonly IMediator _mediator;
        public AppUsersController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var users = await _mediator.Send(new CommonGetAllQuery<AppUser>());
            return users.Any() ? Ok(users.Select(x=>x.MapAppUserDomainToDto())) : NotFound("No user was found");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var user = await _mediator.Send(new CommonByIdQuery<AppUser> { Id = id});
            return user is not null ? Ok(user.MapAppUserDomainToDto()) : NotFound("No user was found");
        }

        [HttpGet("{id:guid}/applications")]
        public async Task<ActionResult> GetAllApplicationsAsync([FromRoute] Guid id)
        {
            var user = await _mediator.Send(new GetAppUserWithIncludeQuery { Id = id });
            return user is not null ? Ok(user.MapAppUserDomainToDto()) : NotFound();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginAppUserDto data)
        {
            var exists = await _mediator.Send(new AppUserByCredintialsQuery{ LoginAppUserDto = data }); 
            return exists ? Ok("Successfull Login") : BadRequest("User password or email is incorrect");
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] CreateAppUserDto data)
        {
            var exists = await _mediator.Send(new AppUserByEmailQuery { Email = data.Email });
            if (exists is not null) return BadRequest("User is already exists with that email"); 
            var result = await _mediator.Send(new CommonCreateCommand<AppUser>{ Entity = data.MapAppUserDtoToDomain() });
            return result.SuccessOrNot ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateAppUserDto data)
        {
            var exists = await _mediator.Send(new CommonByIdQuery<AppUser> { Id = id });
            if (exists is null) return NotFound("User was not found");
            var result = await _mediator.Send(new CommonUpdateCommand<AppUser> { Entity = exists.MapUpdateAppUserDtoToDomain(data) });
            return result.SuccessOrNot ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        { 
            var result = await _mediator.Send(new CommonDeleteCommand<AppUser> { Id = id });
            return result.SuccessOrNot ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
