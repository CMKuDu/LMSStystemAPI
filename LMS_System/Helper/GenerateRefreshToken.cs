using System.Security.Cryptography;
using LMS_System.Helper;
using LMS_System.LMSSystem.Model.DTOs;

namespace LMS_System.Helper
{
    public class GenerateRefreshToken
    {
        public static RefreshToken CreateRefeshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }
    }
}
