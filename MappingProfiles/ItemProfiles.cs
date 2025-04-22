using AutoMapper;
using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.DTOs.Item;
using RestaurantMenuManagementService.Extensions;
using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.MappingProfiles
{
    public class ItemProfiles : Profile
    {
        public ItemProfiles()
        {
            CreateMap<Item,ItemDto>()
                .ForMember(dest => dest.Allergens,
                    opt => opt.MapFrom(src => MapAllergens(src.Allergens)))
                .ForMember(dest => dest.AvailabilityWindows,
                    opt => opt.MapFrom(src => MapAvailabilityWindows(src.AvailabilityWindows)));

            CreateMap<CreateItemDto, Item>()
                .ForMember(dest => dest.Allergens,
                    opt => opt.MapFrom(src => MapAllergens(src.Allergens)))
                .ForMember(dest => dest.AvailabilityWindows,
                    opt => opt.MapFrom(src => MapAvailabilityWindows(src.AvailabilityWindows)));

            CreateMap<UpdateItemDto, Item>()
                .ForMember(dest => dest.Allergens,
                    opt => opt.MapFrom(src => MapAllergens(src.Allergens)))
                .ForMember(dest => dest.AvailabilityWindows,
                    opt => opt.MapFrom(src => MapAvailabilityWindows(src.AvailabilityWindows)));

            CreateMap<Item, CreatedItemDto>()
                .ForMember(dest => dest.Allergens,
                    opt => opt.MapFrom(src => MapAllergens(src.Allergens)))
                .ForMember(dest => dest.AvailabilityWindows,
                    opt => opt.MapFrom(src => MapAvailabilityWindows(src.AvailabilityWindows)));

            CreateMap<Item, UpdatedItemDto>()
                .ForMember(dest => dest.Allergens,
                    opt => opt.MapFrom(src => MapAllergens(src.Allergens)))
                .ForMember(dest => dest.AvailabilityWindows,
                    opt => opt.MapFrom(src => MapAvailabilityWindows(src.AvailabilityWindows)));

            CreateMap<Item, AvailabilityUpdatedItemDto>();
        }

        private static List<AvailabilityWindow>? MapAvailabilityWindows(string availabilityWindowsJson)
        {
            return availabilityWindowsJson.FromJson<List<AvailabilityWindow>>();
        }

        private static string MapAvailabilityWindows(List<AvailabilityWindow> availabilityWindows)
        {
            return availabilityWindows.ToJson();
        }

        private static List<string>? MapAllergens(string allergensJson)
        {
            return allergensJson.FromJson<List<string>>();
        }

        private static string MapAllergens(List<string> allergens)
        {
            return allergens.ToJson();
        }
    }
}
