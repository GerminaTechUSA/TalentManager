using Microsoft.AspNetCore.Mvc;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;

namespace TalentManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftwaresController : ControllerBase
    {
        private readonly ISoftawaresService _softawaresService;
        public SoftwaresController(ISoftawaresService softawaresService)
        {
            _softawaresService = softawaresService;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwaresListDTO>>> GetRoles()
        {
            var softwares = await _softawaresService.GetAllAsync();
            return Ok(softwares);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SoftwaresListDTO>> GetSoftware(int id)
        {
            var softwares = await _softawaresService.GetByIdAsync(id);
            if (softwares == null)
                return NotFound();

            return Ok(softwares);
        }

        [HttpPost]
        public async Task<ActionResult<SoftwaresListDTO>> CreatePerson([FromBody] SoftwaresListDTO dto)
        {
            var created = await _softawaresService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetSoftware), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSoftware(int id, [FromBody] SoftwaresListDTO dto)
        {
            if (dto.Id != 0 && dto.Id != id)
                return BadRequest("Body ID and route ID must match.");

            var success = await _softawaresService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            var deleted = await _softawaresService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
