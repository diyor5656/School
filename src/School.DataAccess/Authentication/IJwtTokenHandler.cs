using School.Core.Entities;
using School.DataAccess.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace School.DataAccess.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(ApplicationUser user);
   
    string GenerateRefreshToken();
}

