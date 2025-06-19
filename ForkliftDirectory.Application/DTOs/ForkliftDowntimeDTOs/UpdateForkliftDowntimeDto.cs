namespace ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs
{
    public class UpdateForkliftDowntimeDto
    {
        public int Id { get; set; }
        public int ForkliftId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }
    }
}
