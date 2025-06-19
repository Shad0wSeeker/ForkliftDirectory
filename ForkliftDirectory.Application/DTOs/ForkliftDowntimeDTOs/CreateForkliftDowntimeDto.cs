using System.ComponentModel.DataAnnotations;

namespace ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs
{
    public class CreateForkliftDowntimeDto
    {
        public int ForkliftId { get; set; }
        [Required]
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }
    }
}
