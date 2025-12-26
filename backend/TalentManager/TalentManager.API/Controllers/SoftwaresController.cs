using Microsoft.AspNetCore.Mvc;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;

namespace TalentManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftwaresController : ControllerBase
    {
        private readonly ISoftwaresService _softwaresService;
        public SoftwaresController(ISoftwaresService softwaresService)
        {
            _softwaresService = softwaresService;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwaresDTO>>> GetRoles()
        {
            var softwares = await _softwaresService.GetAllAsync();
            return Ok(softwares);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SoftwaresDTO>> GetSoftware(int id)
        {
            var softwares = await _softwaresService.GetByIdAsync(id);
            if (softwares == null)
                return NotFound();

            return Ok(softwares);
        }

        [HttpPost]
        public async Task<ActionResult<SoftwaresDTO>> CreateSoftware([FromBody] SoftwaresDTO dto)
        {
            var created = await _softwaresService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetSoftware), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSoftware(int id, [FromBody] SoftwaresDTO dto)
        {
            if (dto.Id != 0 && dto.Id != id)
                return BadRequest("Body ID and route ID must match.");

            var success = await _softwaresService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            var deleted = await _softwaresService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
