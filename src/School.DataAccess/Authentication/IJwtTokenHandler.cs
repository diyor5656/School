using School.Core.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace School.DataAccess.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(User user);
    string GenerateRefreshToken();
}