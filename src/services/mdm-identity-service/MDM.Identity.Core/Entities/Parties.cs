using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyModel;

namespace Identity.Core.Entities
{
    [InjectContext]
    public class Parties : PartiesBase
    {
        public ICollection<Payment> Payments { get; set; }
    }
}
