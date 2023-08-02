using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using AuthorizationModule.Authorization.Roles;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationModule.DataTransferObject.AuthorizationModule
{
    public class RoleDto : EntityDto<int>
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }

        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        public List<string> GrantedPermissions { get; set; }
    }
}