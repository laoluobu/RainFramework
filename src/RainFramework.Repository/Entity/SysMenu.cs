using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RainFramework.Common.Base;

namespace RainFramework.Repository.Entity
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SysMenu : EntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 路由路径
        /// </summary>
        [MaxLength(100)]
        public string Path { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Component { get; set; }

        [Column(TypeName = "json")]
        public Meta Meta { get; set; }

        /// <summary>
        /// 可用角色
        /// </summary>
        [JsonIgnore]
        public List<Role> Roles { get; set; } = new();

        /// <summary>
        /// 父菜单
        /// </summary>
        public SysMenu? Parent { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<SysMenu> Children { get; set; } = new();

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNum { get; set; }
    }

    public class Meta
    {
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? Icon { get; set; }
    }
}