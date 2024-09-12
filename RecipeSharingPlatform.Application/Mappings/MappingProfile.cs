using AutoMapper;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeLabel, LabelDTO>();
        }
    }
}
