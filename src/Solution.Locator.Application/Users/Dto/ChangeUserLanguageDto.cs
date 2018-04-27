using System.ComponentModel.DataAnnotations;

namespace Solution.Locator.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}