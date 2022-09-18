using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbContextEntities.Base
{
    public abstract class BaseEntity
    {
        [Column("Id"), Required]
        public int Id { get; set; }
    }
}
