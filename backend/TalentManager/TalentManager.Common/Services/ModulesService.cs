using Microsoft.EntityFrameworkCore;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;
using TalentManager.Data;
using TalentManager.Data.Entities;

namespace TalentManager.Common.Services
{
    public class ModulesService : IModulesService
    {
        private readonly AppDbContext _context;

        public ModulesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModulesDTO>> GetAllAsync()
        {
            var list = await _context.Modules
                .OrderBy(m => m.Id)
                .ToListAsync();

            return list.Select(MapToDto);
        }

        public async Task<ModulesDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task<ModulesDTO> CreateAsync(ModulesDTO dto)
        {
            var entity = new Modules
            {
                Name = dto.Name,
                SoftwareId = dto.SoftwareId,
                Notes = dto.Notes,
                TargetAudience = dto.TargetAudience
            };

            _context.Modules.Add(entity);
            await _context.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, ModulesDTO dto)
        {
            var entity = await _context.Modules.FindAsync(id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;
            entity.SoftwareId = dto.SoftwareId;
            entity.Notes = dto.Notes;
            entity.TargetAudience = dto.TargetAudience;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Modules.FindAsync(id);
            if (entity == null)
                return false;

            _context.Modules.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // ---- Helpers internos ----

        private static ModulesDTO MapToDto(Modules m)
        {
            return new ModulesDTO()
            {
                Id = m.Id,
                Name = m.Name,
                SoftwareId = m.SoftwareId,
                Notes = m.Notes,
                TargetAudience = m.TargetAudience
            };
        }
    }
}
