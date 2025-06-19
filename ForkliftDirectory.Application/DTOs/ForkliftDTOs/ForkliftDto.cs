namespace ForkliftDirectory.Application.DTOs.ForkliftDTOs
{
    public class ForkliftDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public decimal LoadCapacity { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
