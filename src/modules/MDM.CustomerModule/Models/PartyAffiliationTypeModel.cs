using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyAffiliationType))]
public class PartyAffiliationTypeModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại đối tượng
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    public string? Description { get; set; }
}
