using RecipeSharingPlatform.Application.Common.Models;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel loginModel);
        Task RegisterAsync(RegisterModel registerModel);
        Task<string> GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
