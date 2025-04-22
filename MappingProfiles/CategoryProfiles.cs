using AutoMapper;
using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.DTOs.Category;
using RestaurantMenuManagementService.Extensions;
using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.MappingProfiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreatedCategoryDto>();
            CreateMap<Category, UpdatedCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
        }

    }
}
