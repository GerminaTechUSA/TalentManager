using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManager.Common.DTOs;

namespace TalentManager.Common.Interfaces
{
    public interface ISoftawaresService
    {
        Task<IEnumerable<SoftwaresListDTO>> GetAllAsync();
        Task<SoftwaresListDTO?> GetByIdAsync(int id);
        Task<SoftwaresListDTO> CreateAsync(SoftwaresListDTO dto);
        Task<bool> UpdateAsync(int id, SoftwaresListDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
