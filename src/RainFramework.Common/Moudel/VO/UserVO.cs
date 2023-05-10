#nullable disable
using System.ComponentModel.DataAnnotations;

namespace RainFramework.Common.Moudel.VO
{
    public class UserVO
    {
        [MinLength(2, ErrorMessage = "账号最小长度为2")]
        public string Username { get; init; }

        [MinLength(6, ErrorMessage = "密码最小长度为6")]
        public string Password { get; init; }
    }
}