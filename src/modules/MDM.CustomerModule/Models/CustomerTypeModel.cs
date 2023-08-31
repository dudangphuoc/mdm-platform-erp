using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyIdentification))]
public class CustomerTypeModel : EntityDto<Guid>
{
    /// <summary>
    /// Tên loại khách hàng
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mã loại khách hàng
    /// </summary>
    public Guid? CustomerTypeGroupId { get; set; }

    /// <summary>
    /// Mô tả loại khách hàng
    /// </summary>
    public string? Desc { get; set; }
}