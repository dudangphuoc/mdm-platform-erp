using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EnvironmentModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentModule.DataTransferObject.EnvironmentModule
{
    [AutoMap(typeof(Application))]
    public class ApplicationDto : EntityDto<long>
    {
        [Required]
        [MaxLength(Application.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Application.MaxDescriptionLength)]
        public string Description { get; set; }

        public List<EnvironmentDto> Environments { get; set; }
    }
}
