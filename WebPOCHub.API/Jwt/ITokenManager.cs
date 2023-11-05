using WebPOCHub.Models;

namespace WebPOCHub.API.Jwt
{
    public interface ITokenManager
    {
        string GenerateToken(User model,string roleName);
    }
}
