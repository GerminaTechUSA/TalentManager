using System.Diagnostics.Metrics;

namespace TalentManager.Data.Entities
{
    public class Companies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Persons> Persons { get; set; } = new List<Persons>;
        public ICollection<Experiences> Experiences { get; set; } = new List<Experiences>;
    }
}
