using DataModels.Base;
using ModelEnums;

namespace DataModels.People.Base
{
    public abstract class HumanDataModel : BaseDataModel
    {
        public string Name { get; set; } = default!;
        public string Residence { get; set; } = default!;
        public string? PlaceComesFrom { get; set; }
        public Gender Gender { get; set; }
        public byte Age { get; set; }
    }
}
