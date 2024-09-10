using RecipeSharingPlatform.Application.Common.Models;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel loginModel);
        Task<string> Register(RegisterModel registerModel);
        Task<string> GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
