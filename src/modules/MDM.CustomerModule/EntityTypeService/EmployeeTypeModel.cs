using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using MDM.CustomerModule.Entity.Employee;
using Z.EntityFramework.Plus;

namespace MDM.CustomerModule.EntityTypeService;

internal class EmployeeTypeModel : IEmployeeTypeModel, ISingletonDependency
{
    public IEnumerable<EmployeeType> EmployeeTypes { get; private set; }

    public EmployeeTypeModel(IRepository<EmployeeType, Guid> repository)
    {
        EmployeeTypes = repository.GetAll().FromCache();
        if (EmployeeTypes.Count() == 0)
        {
            throw new UserFriendlyException("ERR_EMPLOYEETYPE_NOT_FOUND");
        }
    }

    public Guid Sales
    {
        get
        {
            var value = EmployeeTypes.FirstOrDefault(p => p.Name.Equals(nameof(Sales)));
            return value == null ? new Guid() : value.Id;
        }
    }

    public Guid CS
    {
        get
        {
            var value = EmployeeTypes.FirstOrDefault(p => p.Name.Equals(nameof(CS)));
            return value == null ? new Guid() : value.Id;
        }
    }

    public Guid Technical
    {
        get
        {
            var value = EmployeeTypes.FirstOrDefault(p => p.Name.Equals(nameof(Technical)));
            return value == null ? new Guid() : value.Id;
        }
    }

    public Guid Support
    {
        get
        {
            var value = EmployeeTypes.FirstOrDefault(p => p.Name.Equals(nameof(Support)));
            return value == null ? new Guid() : value.Id;
        }
    }

    public Guid Chargeable
    {
        get
        {
            var value = EmployeeTypes.FirstOrDefault(p => p.Name.Equals(nameof(Chargeable)));
            return value == null ? new Guid() : value.Id;
        }
    }

    public Guid AgencyEmployee
    {
        get
        {
            var value = EmployeeTypes.FirstOrDefault(p => p.Name.Equals(nameof(AgencyEmployee)));
            return value == null ? new Guid() : value.Id;
        }
    }
}
