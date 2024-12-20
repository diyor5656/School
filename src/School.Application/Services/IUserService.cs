using School.Application.Models;
using School.Application.Models.User;
using School.Core.Enums;

namespace School.Application.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string username, string firstname, string password, UserRole role);
        Task<string> LoginAsync(string username, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
        Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel);
    }
}
