using Abp.AutoMapper;
using Abp.Runtime.Validation;
using EnvironmentModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentModule.DataTransferObject.EnvironmentModule
{
    [AutoMapTo(typeof(Application))]
    public class CreateApplicationDto : IShouldNormalize
    {
        [Required]
        [MaxLength(EntitySettingBase.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(EntitySettingBase.MaxDescriptionLength)]
        public string? Description { get; set; }

        public void Normalize()
        {
            if (Name != null)
            {
                Name = Name.Trim();
            }

            if (Description != null)
            {
                Description = Description.Trim();
            }
        }
    }
}
