using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Core.Entities
{
    [InjectContext]
    [Table("Parties")]
    public class Parties : PartiesBase
    {
        public ICollection<Payment> Payments { get; set; }
    }
}
