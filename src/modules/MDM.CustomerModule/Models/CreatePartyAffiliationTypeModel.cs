using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyAffiliationType))]
public class CreatePartyAffiliationTypeModel
{
    /// <summary>
    /// Tên loại mối liên hệ giữa các party (thực thể/ đối tượng).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mô tả loại mối liên hệ giữa các party (thực thể/ đối tượng).
    /// </summary>
    public string? Description { get; set; }
}