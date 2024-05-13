using Microsoft.AspNetCore.Identity;

namespace BookPublisher.Repository.AUTH
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}