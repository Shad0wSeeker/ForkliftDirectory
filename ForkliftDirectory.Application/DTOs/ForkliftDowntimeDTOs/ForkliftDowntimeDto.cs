namespace ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs
{
    public class ForkliftDowntimeDto
    {
        public int Id { get; set; }
        public int ForkliftId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }

        public string DowntimeDuration
        {
            get
            {
                var end = EndTime ?? DateTime.UtcNow;
                var duration = end - StartTime;
                return $"{(int)duration.TotalHours} ч {duration.Minutes} мин";
            }
        }
    }
}
