using Microsoft.AspNetCore.Mvc;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;

namespace TalentManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesDTO>>> GetRoles()
        {
            var roles = await _rolesService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RolesDTO>> GetRole(int id)
        {
            var role = await _rolesService.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<RolesDTO>> CreateRole([FromBody] RolesDTO dto)
        {
            var created = await _rolesService.CreateAsync(dto, userName: "system");
            return CreatedAtAction(nameof(GetRole), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RolesDTO dto)
        {
            if (dto.Id != 0 && dto.Id != id)
                return BadRequest("Body ID and route ID must match.");

            var success = await _rolesService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var deleted = await _rolesService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
