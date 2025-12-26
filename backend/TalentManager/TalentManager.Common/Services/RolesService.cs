using Microsoft.EntityFrameworkCore;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;
using TalentManager.Data;
using TalentManager.Data.Entities;

namespace TalentManager.Common.Services
{
    public class RolesService : IRolesService
    {
        private readonly AppDbContext _context;

        public RolesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RolesDTO>> GetAllAsync()
        {
            var list = await _context.Roles
                .OrderBy(r => r.Id)
                .ToListAsync();

            return list.Select(MapToDto);
        }

        public async Task<RolesDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.Roles
                .FirstOrDefaultAsync(r => r.Id == id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task<RolesDTO> CreateAsync(RolesDTO dto, string? userName = "system")
        {
            var entity = new Roles
            {
                Name = dto.Name,
                Notes = dto.Notes
            };

            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, RolesDTO dto, string? userName = "system")
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;
            entity.Notes = dto.Notes;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null)
                return false;

            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // ---- Helpers internos ----

        private static RolesDTO MapToDto(Roles r)
        {
            return new RolesDTO()
            {
                Id = r.Id,
                Name = r.Name,
                Notes = r.Notes
            };
        }
    }
}
