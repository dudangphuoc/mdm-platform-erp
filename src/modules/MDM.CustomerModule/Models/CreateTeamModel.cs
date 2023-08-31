using Abp.AutoMapper;
using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(Team))]
public class CreateTeamModel
{
    public Guid PartyId { get; set; }

    public Guid PartyContactTypeId { get; set; }

    public string? IDCard { get; set; }

    public string? TaxCode { get; set; }
}
