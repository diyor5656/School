using AutoMapper;
using School.Application.Models.ModelsByS.Category;
using School.Core.Entities;

namespace School.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // CreateCategoryModel -> Category mapping
            CreateMap<CreatePersonModel, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); // Mapping the 'Name' field (or any other fields you have)

            // UpdateCategoryModel -> Category mapping
            CreateMap<UpdateCategoryModel, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); // Mapping the 'Name' field (or any other fields you have)
        }
    }
}
