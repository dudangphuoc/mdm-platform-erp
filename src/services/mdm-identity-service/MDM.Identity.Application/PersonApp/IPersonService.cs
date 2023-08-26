using Abp.Application.Services;
using MDM.CustomerModule.Models;

namespace Identity.Application.PersonApp;

public interface IPersonService : IAsyncCrudAppService<PersonModel, Guid, GetAllPersonModel, CreatePersonModel, UpdatePersonModel, GetPersonModel, DeletePersonModel>
{

}

