﻿using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class GetPartyRoleTypeModel : IEntityDto<Guid>
{
    public Guid Id { get; set; }
}