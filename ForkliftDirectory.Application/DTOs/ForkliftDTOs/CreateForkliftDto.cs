﻿namespace ForkliftDirectory.Application.DTOs.ForkliftDTOs
{
    public class CreateForkliftDto
    {
        public string Brand { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public decimal LoadCapacity { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
