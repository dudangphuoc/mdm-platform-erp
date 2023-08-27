using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.CustomerModule.Models;
public class GetAllByHierarchicalModel
{
    public Guid? PartyId { get; set; }

    public List<Guid>? PartyAffiliationTypeIds { get; set; }
}