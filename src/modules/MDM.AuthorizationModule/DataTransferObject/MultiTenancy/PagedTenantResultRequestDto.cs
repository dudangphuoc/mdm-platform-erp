using Abp.Application.Services.Dto;

namespace AuthorizationModule.DataTransferObject.MultiTenancy
{
    public class PagedTenantResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}

