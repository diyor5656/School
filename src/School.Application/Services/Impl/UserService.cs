using Microsoft.AspNetCore.Identity;
using School.Application.Helpers;
using School.Application.Models.User;
using School.Core.Entities;
using School.Core.Enums;
using School.DataAccess.Repositories;

namespace School.Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IUserRepository _accountRepository;
    private readonly JwtHelper _jwtHelper;

    public UserService(IUserRepository accountRepository, JwtHelper jwtHelper)
    {
        _accountRepository = accountRepository;
        _jwtHelper = jwtHelper;
    }

    public async Task RegisterAsync(string username, string firstname, string password, UserRole role)
    {
        var newAccount = new User
        {
            UserName = username,
            FirstName = firstname,
            Id = Guid.NewGuid(),
            UserRole = role // Assign the provided role
        };
        var passHash = new PasswordHasher<User>().HashPassword(newAccount, password);
        newAccount.PasswordHash = passHash;
        await _accountRepository.AddAsync(newAccount); // Asinxron chaqiruv
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        // Foydalanuvchini olish
        var account = await _accountRepository.GetUserByUsernameAsync(username);

        if (account == null)
        {
            throw new Exception("Invalid username or password");
        }

        // Parolni tekshirish
        var result = new PasswordHasher<User>()
            .VerifyHashedPassword(account, account.PasswordHash, password);

        if (result == PasswordVerificationResult.Success)
        {
            return _jwtHelper.GenerateToken(account); // Token yaratish
        }
        else
        {
            throw new Exception("Invalid username or password");
        }
    }

    public async Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
    {
        // Foydalanuvchini olish
        var account = await _accountRepository.GetByIdAsync(userId);

        if (account == null)
        {
            throw new Exception("Foydalanuvchi topilmadi");
        }

        // Eski parolni tekshirish
        var passwordHasher = new PasswordHasher<User>();
        var verificationResult = passwordHasher.VerifyHashedPassword(account, account.PasswordHash, currentPassword);

        if (verificationResult != PasswordVerificationResult.Success)
        {
            throw new Exception("Joriy parol noto'g'ri");
        }

        // Yangi parolni xesh qilish
        var newPassHash = passwordHasher.HashPassword(account, newPassword);
        account.PasswordHash = newPassHash;

        // Yangilangan ma'lumotlarni saqlash
        await _accountRepository.UpdateAsync(account); // Asinxron chaqiruv
    }

    Task<ConfirmEmailResponseModel> IUserService.ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
    {
        throw new NotImplementedException();
    }
}
