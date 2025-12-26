using Microsoft.AspNetCore.Mvc;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;

namespace TalentManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulesController : ControllerBase
    {
        private readonly IModulesService _modulesService;
        public ModulesController(IModulesService modulesService)
        {
            _modulesService = modulesService;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModulesDTO>>> GetModules()
        {
            var roles = await _modulesService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModulesDTO>> GetModule(int id)
        {
            var role = await _modulesService.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<ModulesDTO>> CreateModule([FromBody] ModulesDTO dto)
        {
            var created = await _modulesService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetModule), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateModule(int id, [FromBody] ModulesDTO dto)
        {
            if (dto.Id != 0 && dto.Id != id)
                return BadRequest("Body ID and route ID must match.");

            var success = await _modulesService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var deleted = await _modulesService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}