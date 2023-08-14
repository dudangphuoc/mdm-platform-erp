using MDM.Common.EntityFactory;
using MDM.CustomerModule.Entity.PartyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Core.Entities
{
    [InjectContext]
    public class Parties : PartiesBase
    {
        public ICollection<Payment> Payments { get; set; }
    }
}
