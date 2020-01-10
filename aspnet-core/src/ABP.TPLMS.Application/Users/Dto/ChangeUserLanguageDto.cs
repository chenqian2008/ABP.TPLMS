using System.ComponentModel.DataAnnotations;

namespace ABP.TPLMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}