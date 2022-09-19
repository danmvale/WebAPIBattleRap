using BattleRap.API.Controllers.Interfaces;
using BattleRap.API.Models;
using BattleRap.API.Models.DTOs;
using BattleRap.API.Repositories.Interfaces;
using BattleRap.API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleRap.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OrganizationController : ControllerBase, IBaseController<Organization, OrganizationDTO, OrganizationPatchDTO>
{
    private readonly IBaseRepository<Organization> _organizationRepository;

    public OrganizationController(IBaseRepository<Organization> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Organization>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        if (!Paging.IsValid(page, pageSize, out ActionResult? result))
            return result!;

        var organizations = await _organizationRepository.GetAsync(page, pageSize);

        if (!organizations.Any())
            return NotFound("Não foram encontradas rodas culturais.");

        return Ok(organizations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Organization>> Get([FromRoute] int id)
    {
        var organization = await _organizationRepository.GetByIdAsync(id);

        if (organization == null)
            return NotFound($"A roda cultural de ID '{id}' não foi encontrada.");

        return Ok(organization);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Organization>> Post([FromBody] OrganizationDTO organizationDTO)
    {
        var organization = organizationDTO.ToOrganization();
        return await Post(organization);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<ActionResult<Organization>> Post(Organization organization)
    {
        await _organizationRepository.AddAsync(organization);
        return CreatedAtAction(nameof(Get), new { id = organization.ID }, organization);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Organization>> Put([FromRoute] int id, [FromBody] OrganizationDTO organizationDTO)
    {
        var organization = await _organizationRepository.GetByIdAsync(id);

        if (organization == null)
            return await Post(organizationDTO);

        organizationDTO.UpdateOrganization(organization);
        await _organizationRepository.UpdateAsync(organization);

        return Ok(organization);
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<ActionResult<Organization>> Patch([FromRoute] int id, [FromBody] OrganizationPatchDTO organizationPatchDTO)
    {
        var organization = await _organizationRepository.GetByIdAsync(id);

        if (organization == null)
            return NotFound($"A batalha de ID {id} não foi encontrada.");

        organizationPatchDTO.UpdateOrganization(organization);
        await _organizationRepository.UpdateAsync(organization);
        return Ok(organization);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Organization>> Delete([FromRoute] int id)
    {
        if (_organizationRepository.GetByIdAsync(id) == null)
            return NotFound($"A roda cultural de ID '{id}' não foi encontrada.");

        await _organizationRepository.RemoveAsync(id);
        return NoContent();
    }
}
