using RecipeSharingPlatform.Application.Common.Utility;

namespace RecipeSharingPlatform.Application.Common.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? Alias { get; set; }
        public string RoleName { get; set; } = SD.Role_Chef;
        public string Password { get; set; }
    }
}
