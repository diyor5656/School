﻿using School.Core.Enums;

namespace School.Application.Models.User;

public class CreateUserModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public UserRole Role { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }
