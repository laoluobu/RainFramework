using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Moudel.VO
{
    public record UserInfoVO
    {
        public string? Username { get; set; }

        public UserInfo? UserInfo { get; set; }
    }
}