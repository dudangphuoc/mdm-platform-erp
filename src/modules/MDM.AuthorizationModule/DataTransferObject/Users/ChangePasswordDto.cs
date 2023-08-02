using System.ComponentModel.DataAnnotations;

namespace AuthorizationModule.DataTransferObject.Users
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
