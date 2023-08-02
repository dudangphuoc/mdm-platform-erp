using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;
using Environment = EnvironmentModule.Entities.Environment;

namespace EnvironmentModule.DataTransferObject.EnvironmentModule
{
    [AutoMapTo(typeof(Environment))]
    public class CreateEnvironmentDto : IShouldNormalize
    {
        [Required]
        public long ApplicationId { get; set; }

        [Required]
        [MaxLength(Environment.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(Environment.MaxDescriptionLength)]
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
