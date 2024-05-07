using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RainFramework.EFCore.Base
{
    public class EntityBase
    {
        public virtual int Id { get; set; }

        [Comment("创建时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime CreatedTime { get; set; }

        [Comment("修改时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime UpdatedTime { get; set; }
    }
}