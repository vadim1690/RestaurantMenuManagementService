using AutoMapper;
using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.DTOs.Resturant;
using RestaurantMenuManagementService.Extensions;
using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.MappingProfiles
{
    public class ResturantProfiles : Profile
    {
        public ResturantProfiles()
        {
            CreateMap<Resturant, ResturantDto>()
                .ForMember(dest => dest.OperatingHours,
                opt => opt.MapFrom(src => MapOperatingHours(src.OperatingHours)));
        }

        private static List<OperationHour>? MapOperatingHours(string operatingHoursJson)
        {
            return operatingHoursJson.FromJson<List<OperationHour>>();
        }
    }
}
