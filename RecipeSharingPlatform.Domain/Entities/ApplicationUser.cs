using Microsoft.AspNetCore.Identity;

namespace RecipeSharingPlatform.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? Alias { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
