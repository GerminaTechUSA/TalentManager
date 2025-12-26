using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManager.Common.DTOs;

namespace TalentManager.Common.Interfaces
{
    public interface ISoftwaresService
    {
        Task<IEnumerable<SoftwaresDTO>> GetAllAsync();
        Task<SoftwaresDTO?> GetByIdAsync(int id);
        Task<SoftwaresDTO> CreateAsync(SoftwaresDTO dto);
        Task<bool> UpdateAsync(int id, SoftwaresDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
