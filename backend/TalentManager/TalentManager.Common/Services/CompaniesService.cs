using Microsoft.EntityFrameworkCore;
using TalentManager.Common.DTOs;
using TalentManager.Common.Interfaces;
using TalentManager.Data;
using TalentManager.Data.Entities;
using System;

namespace TalentManager.Common.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly AppDbContext _context;

        public CompaniesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompaniesListDTO>> GetAllAsync()
        {
            var list = await _context.Companies
                .OrderBy(c => c.Name)
                .ToListAsync();

            return list.Select(MapToDto);
        }
        
        public async Task<CompaniesListDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.Companies
                .FirstOrDefaultAsync(c => c.Id == id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task<CompaniesListDTO> CreateAsync(CompaniesListDTO dto, string? userName = "system")
        {
            var entity = new Companies
            {
                Name = dto.Name,
            };

            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();

            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, CompaniesListDTO dto, string? username = "system")
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return false;

            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private static CompaniesListDTO MapToDto(Companies c)
        {
            return new CompaniesListDTO
            {
                Id = c.Id,
                Name = c.Name,
            };
        }
    }
}
