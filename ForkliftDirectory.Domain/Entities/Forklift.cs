namespace ForkliftDirectory.Domain.Entities
{
    public class Forklift
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public decimal LoadCapacity { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public List<ForkliftDowntime> Downtimes { get; set; } = new();
    }
}
