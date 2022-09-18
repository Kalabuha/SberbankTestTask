using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbContextEntities.People.Base;

namespace DbContextEntities.People
{
    [Table("Clients")]
    public class ClientEntity : HumanEntity
    {
        [Column("Number"), Required]
        public int ClientNumber { get; set; }
    }
}
