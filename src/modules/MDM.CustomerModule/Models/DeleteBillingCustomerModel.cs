using Abp.Application.Services.Dto;

namespace MDM.CustomerModule.Models;
public class DeleteBillingCustomerModel : IEntityDto<Guid>
{
    /// <summary>
    /// Id thông tin hóa đơn của KH (đại lý).
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Id party (thực thể/ đối tượng).
    /// </summary>
    public Guid PartyId { get; set; }
}
