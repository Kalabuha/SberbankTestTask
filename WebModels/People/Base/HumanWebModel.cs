using WebModels.Base;
using ModelEnums;

namespace WebModels.People.Base
{
    public abstract class HumanWebModel : BaseWebModel
    {
        public string Name { get; set; } = default!;
        public string Residence { get; set; } = default!;
        public string? PlaceComesFrom { get; set; }
        public string Gender { get; set; } = default!;
        public byte Age { get; set; }
    }
}
