using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace RainFramework.Common.Moudel.DTO
{
    public record AuthUserDTO
    {
        public int Id { get; init; }

        public string Username { get; init; }

        public string IpAddress { get; set; }

        public List<string> Roles { get; init; } = new();
    }
}
