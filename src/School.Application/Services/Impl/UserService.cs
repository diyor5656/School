using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using School.Application.Common.Email;
using School.Application.Exceptions;
using School.Application.Helpers;
using School.Application.Models;
using School.Application.Models.User;
using School.Application.Templates;
using School.DataAccess.Identity;

namespace School.Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITemplateService _templateService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<UserService> _logger;

    public UserService(IMapper mapper,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        ITemplateService templateService,
        IEmailService emailService,
        ILogger<UserService> logger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _templateService = templateService;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel)
    {
        //Password -- &,$ kabi belgi son va Bosh va kichik harflardan katta bo'lsin
        var user = _mapper.Map<ApplicationUser>(createUserModel);
        var result = await _userManager.CreateAsync(user, createUserModel.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            _logger.LogError("Failed to create user: {Errors}", errors);
            throw new BadRequestException(errors);
        }

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var emailTemplate = await _templateService.GetTemplateAsync(TemplateConstants.ConfirmationEmail);

        if (string.IsNullOrEmpty(emailTemplate))
        {
            _logger.LogError("Email template not found for user creation.");
            throw new BadRequestException("Email template not found.");
        }

        var emailBody = _templateService.ReplaceInTemplate(emailTemplate,
            new Dictionary<string, string> { { "{UserId}", user.Id }, { "{Token}", token } });

        await _emailService.SendEmailAsync(EmailMessage.Create(user.Email, emailBody, "[School] Confirm your email"));

        return new CreateUserResponseModel
        {
            Id = Guid.Parse(user.Id)
        };
    }

    public async Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginUserModel.Username);

        if (user == null)
        {
            _logger.LogWarning("Login failed for username: {Username}", loginUserModel.Username);
            throw new BadRequestException("Username or password is incorrect");
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserModel.Password, false, false);

        if (!signInResult.Succeeded)
        {
            _logger.LogWarning("Login failed for username: {Username}", loginUserModel.Username);
            throw new BadRequestException("Username or password is incorrect");
        }

        var token = JwtHelper.GenerateToken(user, _configuration);

        return new LoginResponseModel
        {
            Username = user.UserName,
            Email = user.Email,
            Token = token
        };
    }

    public async Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
    {
        var user = await _userManager.FindByIdAsync(confirmEmailModel.UserId);

        if (user == null)
        {
            _logger.LogWarning("Email confirmation failed: User not found with ID {UserId}", confirmEmailModel.UserId);
            throw new UnprocessableRequestException("Your verification link is incorrect");
        }

        var result = await _userManager.ConfirmEmailAsync(user, confirmEmailModel.Token);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            _logger.LogWarning("Email confirmation failed for user {UserId}: {Errors}", confirmEmailModel.UserId, errors);
            throw new UnprocessableRequestException("Your verification link has expired");
        }

        return new ConfirmEmailResponseModel
        {
            Confirmed = true
        };
    }

    public async Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            _logger.LogWarning("Change password failed: User not found with ID {UserId}", userId);
            throw new NotFoundException("User not found");
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordModel.OldPassword, changePasswordModel.NewPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            _logger.LogError("Change password failed for user {UserId}: {Errors}", userId, errors);
            throw new BadRequestException(errors);
        }

        return new BaseResponseModel
        {
            Id = Guid.Parse(user.Id)
        };
    }
}

