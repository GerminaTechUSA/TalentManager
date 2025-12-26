namespace TalentManager.Common.DTOs
{
    public class ModulesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int SoftwareId { get; set; }

        public string? Notes { get; set; }

        public string TargetAudience { get; set; }
    }
}
