using System.ComponentModel.DataAnnotations;

namespace AuthorizationModule.DataTransferObject.Users
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}