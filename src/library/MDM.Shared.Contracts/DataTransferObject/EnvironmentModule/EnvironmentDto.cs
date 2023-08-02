using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using Environment = EnvironmentModule.Entities.Environment;

namespace EnvironmentModule.DataTransferObject.EnvironmentModule
{
    [AutoMap(typeof(Environment))]
    public class EnvironmentDto : EntityDto<long>
    {
        [Required]
        public long ApplicationId { get; set; }

        [Required]
        [MaxLength(Environment.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Environment.MaxDescriptionLength)]
        public string Description { get; set; }

        public string SecretEncode { get; set; }

        public List<AppSettingDto> AppSettings { get; set; }

        public ApplicationDto Application { get; set; }
    }
}
