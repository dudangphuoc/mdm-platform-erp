using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDM.CustomerModule.Entity.PartyModel;
using MDM.CustomerModule.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Application.PartyTypeApp;
public class PartyTypeService : AsyncCrudAppService<PartyType, PartyTypeModel, Guid, GetAllPartyTypeModel, CreatePartyTypeModel, UpdatePartyTypeModel, GetPartyTypeModel, DeletePartyTypeModel>, IPartyTypeService
{
    public PartyTypeService(IRepository<PartyType, Guid> repository) : base(repository)
    {
    }

    /// <summary>
    /// Cập nhật loại đối tượng
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override Task<PartyTypeModel> UpdateAsync(UpdatePartyTypeModel input)
    {
        return base.UpdateAsync(input);
    }

    /// <summary>
    /// Xóa loại đối tượng
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override Task DeleteAsync(DeletePartyTypeModel input)
    {
        return base.DeleteAsync(input);
    }

    /// <summary>
    /// Danh sách loại đối tượng
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override Task<PagedResultDto<PartyTypeModel>> GetAllAsync(GetAllPartyTypeModel input)
    {
        return base.GetAllAsync(input);
    }

    /// <summary>
    /// Thôn tin chi tiết loại đối tượng
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public override Task<PartyTypeModel> GetAsync(GetPartyTypeModel input)
    {
        return base.GetAsync(input);
    }

    [AllowAnonymous]
    public override Task<PartyTypeModel> CreateAsync(CreatePartyTypeModel input)
    {
        return base.CreateAsync(input);
    }
}
