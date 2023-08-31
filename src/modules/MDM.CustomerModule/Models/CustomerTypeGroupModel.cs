using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyIdentification))]
public class CustomerTypeGroupModel : EntityDto<Guid>
{
    public string Name { get; set; }
}

