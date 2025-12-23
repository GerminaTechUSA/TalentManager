using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentManager.Common.DTOs
{
    public class RolesListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Notes { get; set; }
    }
}
