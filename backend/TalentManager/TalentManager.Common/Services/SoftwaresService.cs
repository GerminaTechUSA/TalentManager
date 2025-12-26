using Microsoft.EntityFrameworkCore;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;
using TalentManager.Data;
using TalentManager.Data.Entities;

namespace TalentManager.Common.Services
{
    public class SoftwaresService : ISoftwaresService
    {
        private readonly AppDbContext _context;

        public SoftwaresService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SoftwaresDTO>> GetAllAsync()
        {
            var list = await _context.Softwares
                .OrderBy(s => s.Id)
                .ToListAsync();

            return list.Select(MapToDto);
        }

        public async Task<SoftwaresDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.Softwares
                .FirstOrDefaultAsync(s => s.Id == id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task<SoftwaresDTO> CreateAsync(SoftwaresDTO dto)
        {
            var entity = new Softwares()
            {
                Name = dto.Name
            };

            _context.Softwares.Add(entity);
            await _context.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, SoftwaresDTO dto)
        {
            var entity = await _context.Softwares.FindAsync(id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Softwares.FindAsync(id);
            if (entity == null)
                return false;

            _context.Softwares.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // ---- Helpers internos ----

        private static SoftwaresDTO MapToDto(Softwares s)
        {
            return new SoftwaresDTO()
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }
}
