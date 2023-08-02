using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AuthorizationModule.MultiTenancy;

namespace AuthorizationModule.DataTransferObject.Sessions
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
