using TalentManager.Common.DTOs;

namespace TalentManager.Common.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesListDTO>> GetAllAsync();
        Task<RolesListDTO?> GetByIdAsync(int id);
        Task<RolesListDTO> CreateAsync(RolesListDTO dto, string? userName = null);
        Task<bool> UpdateAsync(int id, RolesListDTO dto, string? userName = null);
        Task<bool> DeleteAsync(int id);
    }
}
