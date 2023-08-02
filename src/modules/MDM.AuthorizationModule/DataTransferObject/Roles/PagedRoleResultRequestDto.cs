using Abp.Application.Services.Dto;

namespace AuthorizationModule.DataTransferObject.AuthorizationModule
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

