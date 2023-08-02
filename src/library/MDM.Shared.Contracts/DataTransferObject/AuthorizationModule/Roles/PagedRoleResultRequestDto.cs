using Abp.Application.Services.Dto;

namespace EnvironmentModule.DataTransferObject.AuthorizationModule
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

