using TalentManager.Common.DTOs;

namespace TalentManager.Common.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesDTO>> GetAllAsync();
        Task<RolesDTO?> GetByIdAsync(int id);
        Task<RolesDTO> CreateAsync(RolesDTO dto, string? userName = null);
        Task<bool> UpdateAsync(int id, RolesDTO dto, string? userName = null);
        Task<bool> DeleteAsync(int id);
    }
}
