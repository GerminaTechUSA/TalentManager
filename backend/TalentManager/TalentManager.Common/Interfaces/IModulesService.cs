using TalentManager.Common.DTOs;

namespace TalentManager.Common.Interfaces
{
    public interface IModulesService
    {
        Task<IEnumerable<ModulesDTO>> GetAllAsync();
        Task<ModulesDTO?> GetByIdAsync(int id);
        Task<ModulesDTO> CreateAsync(ModulesDTO dto);
        Task<bool> UpdateAsync(int id, ModulesDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
