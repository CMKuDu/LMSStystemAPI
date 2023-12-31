﻿using System.ComponentModel.DataAnnotations;

namespace LMS_System.LMSSystym.Model.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string UserImage { get; set; } = string.Empty;

        public string PasswordResetToken { get; set; } = string.Empty;

        public DateTime? ResetTokenExpries { get; set; }

        public string VerificationToken { get; set; } = string.Empty;

        public DateTime? VerifyAt { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime? RefreshTokenCreated { get; set; }

        public DateTime? RefreshTokenExpries { get; set; }
    }
}
