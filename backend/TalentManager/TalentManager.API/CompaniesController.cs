using Microsoft.AspNetCore.Mvc;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;

namespace TalentManager.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        // GET: api/companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompaniesListDTO>>> GetCompanies()
        {
            var companies = await _companiesService.GetAllAsync();
            return Ok(companies);
        }

        // GET: api/companies/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompaniesListDTO>> GetCompany(int id)
        {
            var company = await _companiesService.GetByIdAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        // POST: api/companies
        [HttpPost]
        public async Task<ActionResult<CompaniesListDTO>> CreateCompany([FromBody] CompaniesListDTO dto)
        {
            var created = await _companiesService.CreateAsync(dto, userName: "system");
            return CreatedAtAction(nameof(GetCompany), new { id = created.Id }, created);
        }

        // PUT: api/companies/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompaniesListDTO dto)
        {
            if (dto.Id != 0 && dto.Id != id)
                return BadRequest("Body ID and route ID must match.");

            var sucess = await _companiesService.UpdateAsync(id, dto, userName: "system");
            if (!sucess)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/companies/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var deleted = await _companiesService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
