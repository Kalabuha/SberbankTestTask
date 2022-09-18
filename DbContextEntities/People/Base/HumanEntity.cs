using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbContextEntities.Base;
using ModelEnums;

namespace DbContextEntities.People.Base
{
    public abstract class HumanEntity : BaseEntity
    {
        [Column("Name"), MaxLength(100), Required]
        public string Name { get; set; } = default!;

        [Column("Residence"), MaxLength(100), Required]
        public string Residence { get; set; } = default!;

        [Column("From"), MaxLength(100)]
        public string? PlaceComesFrom { get; set; }

        [Column("Gender"), Required]
        public Gender Gender { get; set; }

        [Column("Age"), Required]
        public byte Age { get; set; }
    }
}
