#nullable disable

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RainFramework.Common.Base;
using WMS.Repository.Entity;

namespace RainFramework.Repository.Entity
{
    public class SysMenu : EntityBase
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Component { get; set; }

        [Column(TypeName = "json")]
        public Meta Meta { get; set; }

        public List<Role> Roles { get; set; } = new();

        /// <summary>
        /// 父菜单
        /// </summary>
        public SysMenu Parent { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<SysMenu> Children { get; set; } = new ();

    }

    public class Meta
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}