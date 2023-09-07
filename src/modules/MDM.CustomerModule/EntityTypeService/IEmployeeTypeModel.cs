using MDM.CustomerModule.Entity.Employee;

namespace MDM.CustomerModule.EntityTypeService;

public interface IEmployeeTypeModel
{
    IEnumerable<EmployeeType> EmployeeTypes { get; }
    Guid Sales { get; }
    Guid CS { get; }
    Guid Technical { get; }
    Guid Support { get; }
    Guid Chargeable { get; }
    Guid AgencyEmployee { get; }
}
