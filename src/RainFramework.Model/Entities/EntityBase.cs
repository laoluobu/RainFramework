using System.ComponentModel.DataAnnotations.Schema;

namespace RainFramework.Model.Entities
{
    public class EntityBase
    {
        public virtual int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime CreatedTime { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime UpdatedTime { get; set; }
    }
}