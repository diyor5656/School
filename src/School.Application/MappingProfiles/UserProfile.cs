using AutoMapper;
using School.Application.Models.User;
using School.DataAccess.Identity;

namespace School.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, ApplicationUser>();
    }
}
