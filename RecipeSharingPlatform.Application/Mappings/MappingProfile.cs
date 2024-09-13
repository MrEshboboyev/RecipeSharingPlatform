using AutoMapper;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Recipe, RecipeDTO>()
            .ForMember(dest => dest.ChefName, opt => opt.MapFrom(src => src.Chef.FullName)) // Example
            .ForMember(dest => dest.Labels, opt => opt.MapFrom(src => src.Labels));     // Example

            CreateMap<RecipeLabel, LabelDTO>();
            CreateMap<RecipeImage, ImageDTO>();
        }
    }
}
