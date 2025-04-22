using AutoMapper;
using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.DTOs.AuditLog;
using RestaurantMenuManagementService.DTOs.Item;
using RestaurantMenuManagementService.Extensions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RestaurantMenuManagementService.MappingProfiles
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            CreateMap<AuditLog, AuditLogDto>()
                .ForMember(dest => dest.Changes, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    if (string.IsNullOrEmpty(src.Changes))
                        return new Dictionary<string, object>();

                    try
                    {
                        return JsonSerializer.Deserialize<Dictionary<string, object>>(src.Changes,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    catch
                    {
                        return new Dictionary<string, object>();
                    }
                }));
        }
    }
}
