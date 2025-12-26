namespace TalentManager.Data.Entities
{
    public class Modules
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int SoftwareId { get; set; }
        public Softwares? Software { get; set; }

        public string? Notes { get; set; }

        public string TargetAudience { get; set; }
    }
}