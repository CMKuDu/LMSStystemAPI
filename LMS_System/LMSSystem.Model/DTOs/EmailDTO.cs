﻿namespace LMS_System.LMSSystem.Model.DTOs
{
    public class EmailDTO
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string? Body { get; set; }
    }
}
