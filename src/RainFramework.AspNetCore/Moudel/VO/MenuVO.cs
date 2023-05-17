using RainFramework.Repository.Entity;

namespace RainFramework.AspNetCore.Moudel.VO
{
    public class MenuVO
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public string Component { get; set; }

        public Meta Meta { get; set; }

        public int? ParentId { get; set; }

        public List<SysMenu> Children { get; set; } = new();

        public bool Hidden { get; set; }

        public int OrderNum { get; set; }
    }
}