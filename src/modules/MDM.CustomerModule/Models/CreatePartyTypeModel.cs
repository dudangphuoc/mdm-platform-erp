using Abp.AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;
using System.Net.Mail;

namespace MDM.CustomerModule.Models;

[AutoMap(typeof(PartyType))]
public class CreatePartyTypeModel
{
    /// <summary>
    /// Tên loại party (thực thể/ đối tượng).
    /// </summary>
    public string Name { get; set; }
}