namespace TalentManager.Data.Entities
{
    public class Softwares
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Modules> Modules { get; set; } = new List<Modules>();

    }
}
