using System.ComponentModel.DataAnnotations.Schema;

namespace AubilousTouch.Core.Models
{
    public class EntityBase
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
