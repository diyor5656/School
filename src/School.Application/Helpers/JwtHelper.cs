using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using School.Core.Entities;
using School.DataAccess.Identity;

namespace School.Application.Helpers;

public class JwtHelper
{
    private readonly IOptions<AuthSettings> options;

    public JwtHelper(IOptions<AuthSettings> options)
    {
        this.options = options;
    }
    public string GenerateToken(User account)
    {

        var claims = new List<Claim>
        {
            new Claim("userName", account.UserName),
            new Claim("id", account.Id.ToString()),
            new Claim(ClaimTypes.Role, account.UserRole.ToString())// Add role to claims
        };

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(options.Value.Expires),
            claims: claims,
            signingCredentials:
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature));

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}

