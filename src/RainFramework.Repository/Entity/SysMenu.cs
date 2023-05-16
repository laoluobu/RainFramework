using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RainFramework.Common.Base;

namespace RainFramework.Repository.Entity
{
    public class SysMenu : EntityBase
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Path { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Component { get; set; }

        [Column(TypeName = "json")]
        public Meta Meta { get; set; }

        [JsonIgnore]
        public List<Role> Roles { get; set; } = new();

        /// <summary>
        /// 父菜单
        /// </summary>
        public SysMenu? Parent { get; set; }

        public int? ParentId { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<SysMenu> Children { get; set; } = new();

        public bool Hidden { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNum { get; set; }
    }

    public class Meta
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Icon { get; set; }
    }
}