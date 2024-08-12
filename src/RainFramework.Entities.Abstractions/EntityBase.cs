using System.ComponentModel.DataAnnotations.Schema;

namespace RainFramework.Entities.Abstractions
{
    public class EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual int Id { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime UpdatedTime { get; set; }
    }
}