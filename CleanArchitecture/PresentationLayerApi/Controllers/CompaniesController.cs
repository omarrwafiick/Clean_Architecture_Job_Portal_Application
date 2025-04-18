using ApplicationLayer.Commands.Common;
using ApplicationLayer.Commands.CompanyCommands;
using ApplicationLayer.Dtos;
using ApplicationLayer.Extensions;
using ApplicationLayer.Queries.Common;
using ApplicationLayer.Queries.CompanyQueries;
using DomainLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace PresentationLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var companies = await _mediator.Send(new CommonGetAllQuery<Company>());
            return companies.Any() ? Ok(companies.Select(c => c.MapCompanyDomainToDto())) : NotFound("No company was found");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var company = await _mediator.Send(new CommonByIdQuery<Company> { Id = id });
            return company is not null ? Ok(company.MapCompanyDomainToDto()) : NotFound($"No company was found using this id => {id}");
        }

        [HttpGet("companyposts/{id:guid}")]
        public async Task<ActionResult> GetAllCompanyPostsAsync([FromRoute] Guid id)
        {
            var company = await _mediator.Send(new GetCompanyPostsQuery { Id = id });
            return company is not null ? Ok(company.MapCompanyDomainToDtoWithPosts()) 
                                       : NotFound($"No company was found using this id => {id}");
        }

        [HttpGet("companyemployees/{id:guid}")]
        public async Task<ActionResult> GetAllCompanyEmployeesAsync([FromRoute] Guid id)
        {
            var company = await _mediator.Send(new GetCompanyEmployeesQuery { Id = id });
            return company is not null ? Ok(company.MapCompanyDomainToDtoWithEmployees()) 
                                       : NotFound($"No company was found using this id => {id}");
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCompanyDto data)
        {
            var isExists = await _mediator.Send(new CommonGetWithConditionQuery<Company> { condition = x => x.Name == data.Name });
            if (isExists is not null) return BadRequest($"Company is already exists with name {data.Name}");
            var newCompany = await _mediator.Send(new CommonCreateCommand<Company> { Entity = data.MapCompanyDtoToDomain() });
            return newCompany.SuccessOrNot? Ok(newCompany.Message) : BadRequest(newCompany.Message);
        }

        [HttpPost("{employeeid:guid}/{companyid:guid}")]
        public async Task<ActionResult> AddEmployeeAsync([FromRoute] Guid employeeid, [FromRoute] Guid companyid)
        {
            var newEmployee = await _mediator.Send(new AddEmployeeToCompanyCommand { EmployeeId = employeeid, CompanyId = companyid});
            return newEmployee.SuccessOrNot ? Ok(newEmployee.Message) : BadRequest(newEmployee.Message);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCompanyDto data)
        {
            var exists = await _mediator.Send(new CommonByIdQuery<Company> { Id = id });
            if (exists is null) return NotFound("Company was not found");
            var updatedCompany = await _mediator.Send(new CommonUpdateCommand<Company> { Entity = data.MapUpdateCompanyDtoToDomain(exists) });
            return updatedCompany.SuccessOrNot ? Ok(updatedCompany.Message) : BadRequest(updatedCompany.Message);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var company = await _mediator.Send(new CommonDeleteCommand<Company> { Id = id });
            return company.SuccessOrNot ? Ok(company.Message) : BadRequest(company.Message);
        }

        [HttpDelete("{employeeid:guid}")]
        public async Task<ActionResult> RemoveEmployeeAsync([FromRoute] Guid employeeid)
        {
            var removedEmployee = await _mediator.Send(new RemoveEmployeeFromCompanyCommand { EmployeeId = employeeid });
            return removedEmployee.SuccessOrNot ? Ok(removedEmployee.Message) : BadRequest(removedEmployee.Message);
        }
    }
}
