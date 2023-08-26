using Abp.Application.Services.Dto;
using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Models;

public class PersonModel : EntityDto<Guid>
{
    public string Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public EGender? Gender { get; set; }
}