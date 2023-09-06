﻿using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;

public class DeleteCustomerSegmentModel : IEntityDto<Guid>
{
    /// <summary>
    /// Id cụm khách hàng.
    /// </summary>
    public Guid Id { get; set; }
}
