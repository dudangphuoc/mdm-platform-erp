using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EnvironmentModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentModule.DataTransferObject.EnvironmentModule
{
    [AutoMap(typeof(AppSetting))]
    public class AppSettingDto : EntityDto<long>
    {
        [Required]
        [MaxLength(EntitySettingBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EntitySettingBase.MaxDescriptionLength)]
        public string Description { get; set; }

        public long EnvironmentId { get; set; }

        public string JsonValues { get; set; }

        public EnvironmentDto Environment { get; set; }

    }

    [AutoMap(typeof(AppSetting))]
    public class ApplicationSettingDto
    {
        public string Version { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }
    }
}
