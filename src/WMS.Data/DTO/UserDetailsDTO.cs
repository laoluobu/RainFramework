#nullable disable

namespace WMS.Models.DTO
{
    public record UserDetailsDTO
    {
        public int Id { get; init; }

        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public List<string> Roles { get; init; }

        public string IpAddress { get; init; }

        public DateTime LastLoginTime { get; init; }

        public DateTime ExpireTime { get; init; }

        public int IsDisable { get; init; }
    }
}
