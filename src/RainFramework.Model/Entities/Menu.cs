using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RainFramework.Entities.Abstractions;

namespace RainFramework.Model.Entities
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class Menu : EntityBase
    {

        /// <summary>
        /// 路由路径
        /// </summary>
        [MaxLength(100)]
        public string Path { get; set; } = null!;

        /// <summary>
        /// 菜单名称
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Component { get; set; } = null!;

        [Column(TypeName = "json")]
        public Meta Meta { get; set; } = null!;

        /// <summary>
        /// 可用角色
        /// </summary>
        public List<Role> Roles { get; set; } = new();

        /// <summary>
        /// 父菜单
        /// </summary>
        public Menu? Parent { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<Menu> Children { get; set; } = new();

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNum { get; set; }
    }


    /// <summary>
    ///  标签
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? Icon { get; set; }
    }
}