using School.Core.Common;
using School.Core.Entities.Common;
using School.Core.Entities.Users;
using School.Core.Enums;

namespace School.Core.Entities;

public sealed class User : BaseEntity
{
    private const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;

    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public UserRole UserRole { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpireDate { get; private set; }

    public Guid AddressId { get; set; }
    public Address? Address { get; set; }
    public string UserName { get; set; }

    public void UpdateRefreshToken(
        string refreshToken,
        int expireDateInMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
    {
        RefreshToken = refreshToken;

        RefreshTokenExpireDate = DateTime.UtcNow
            .AddMinutes(expireDateInMinutes);
    }
}