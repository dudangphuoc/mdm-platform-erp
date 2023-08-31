﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyIdentification))]
public class UpdatePartyIdentificationTypeModel : CreatePartyIdentificationTypeModel, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
