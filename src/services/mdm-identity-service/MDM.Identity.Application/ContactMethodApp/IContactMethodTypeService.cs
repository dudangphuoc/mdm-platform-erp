using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.ContactMethodApp;

public interface IContactMethodTypeService : IAsyncCrudAppService<ContactMethodTypeModel, Guid, GetAllContactMethodTypeModel, CreateContactMethodTypeModel, UpdateContactMethodTypeModel, GetContactMethodTypeModel, DeleteContactMethodTypeModel>
{

}

