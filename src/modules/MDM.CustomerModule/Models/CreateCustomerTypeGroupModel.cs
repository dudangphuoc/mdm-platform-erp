using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyIdentification))]
public class CreateCustomerTypeGroupModel
{
    public string Name { get; set; }
}

