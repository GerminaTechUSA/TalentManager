using System.Configuration;
using TalentManager.Common.DTOs;

namespace TalentManager.Common.Interfaces
{
    public interface ICompaniesService
    {
        Task<IEnumerable<CompaniesListDTO>> GetAllAsync();
        Task<CompaniesListDTO?> GetByIdAsync(int id);
        Task<CompaniesListDTO> CreateAsync(CompaniesListDTO dto, string? userName = null);
        Task<bool> UpdateAsync(int id, CompaniesListDTO dto, string? userName = null);
        Task<bool> DeleteAsync(int id);
    }
}
