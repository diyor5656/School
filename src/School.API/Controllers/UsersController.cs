using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.Models;
using School.Application.Models.User;
using School.Application.Services;

namespace School.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    // Foydalanuvchini ro‘yxatdan o‘tkazish
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUserModel createUserModel)
    {
        try
        {
            await _userService.RegisterAsync(
                createUserModel.Username,
                createUserModel.FirstName,
                createUserModel.Password,
                createUserModel.Role);

            _logger.LogInformation("Foydalanuvchi {UserName} muvaffaqiyatli ro‘yxatdan o‘tdi.", createUserModel.Username);
            return Ok(new { Message = "Foydalanuvchi muvaffaqiyatli ro‘yxatdan o‘tdi." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Foydalanuvchini ro‘yxatdan o‘tkazishda xatolik.");
            return BadRequest(new { Error = ex.Message });
        }
    }

    // Foydalanuvchini autentifikatsiya qilish
    [HttpPost("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserModel loginUserModel)
    {
        try
        {
            var token = await _userService.LoginAsync(loginUserModel.Username, loginUserModel.Password);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("UserSession", token, cookieOptions);

            _logger.LogInformation("Foydalanuvchi {UserName} muvaffaqiyatli tizimga kirdi.", loginUserModel.Username);
            return Ok(new { Token = token, Message = "Muvaffaqiyatli autentifikatsiya." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Autentifikatsiya jarayonida xatolik yuz berdi.");
            return Unauthorized(new { Error = ex.Message });
        }
    }

    // Emailni tasdiqlash
    [HttpPost("confirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmEmailModel confirmEmailModel)
    {
        try
        {
            var result = await _userService.ConfirmEmailAsync(confirmEmailModel);

            if (result.IsSuccess)
            {
                _logger.LogInformation("Email {Email} muvaffaqiyatli tasdiqlandi.", confirmEmailModel.UserId);
                return Ok(new { Message = "Email muvaffaqiyatli tasdiqlandi." });
            }

            return BadRequest(new { Message = "Emailni tasdiqlashda xatolik." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Emailni tasdiqlash jarayonida xatolik yuz berdi.");
            return BadRequest(new { Error = ex.Message });
        }
    }

   
}
