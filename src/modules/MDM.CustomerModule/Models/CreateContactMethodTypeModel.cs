using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyContact;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyIdentification))]
public class CreateContactMethodTypeModel
{
    /// <summary>
    /// Tên loại phương thức liên hệ
    /// </summary>
    public string Name { get; set; }
}
