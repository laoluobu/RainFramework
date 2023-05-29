using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Moudel.VO
{
    public record MenuVO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 元数据
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// 父菜单Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 子菜单列表
        /// </summary>
        public List<MenuVO> Children { get; set; } = new();

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 菜单排序
        /// </summary>
        public int OrderNum { get; set; }
    }
}