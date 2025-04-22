using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.Extensions;
using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!dbContext.Resturants.Any())
            {
                await InitializeResturants(dbContext);
            }
        }

        private static async Task InitializeResturants(AppDbContext dbContext)
        {
            var restaurants = new List<Resturant>
                {
                    new Resturant
                    {
                        Name = "La Bella Italia",
                        Description = "Authentic Italian cuisine with a cozy atmosphere and traditional recipes passed down through generations.",
                        CuisineType = "Italian",
                        OperatingHours = new List<OperationHour>
                        {
                            new OperationHour { Day = "Monday", OpenTime = "11:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Tuesday", OpenTime = "11:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Wednesday", OpenTime = "11:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Thursday", OpenTime = "11:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Friday", OpenTime = "11:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Saturday", OpenTime = "12:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Sunday", OpenTime = "12:00", CloseTime = "23:00" }
                        }.ToJson()
                    },
                    new Resturant
                    {
                        Name = "Sushi Haven",
                        Description = "Premium Japanese restaurant specializing in fresh sushi and sashimi, prepared by master chefs.",
                        CuisineType = "Japanese",
                        OperatingHours = new List<OperationHour>
                        {
                            new OperationHour { Day = "Monday", OpenTime = "Closed", CloseTime = "Closed" },
                            new OperationHour { Day = "Tuesday", OpenTime = "12:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Wednesday", OpenTime = "12:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Thursday", OpenTime = "12:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Friday", OpenTime = "12:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Saturday", OpenTime = "12:00", CloseTime = "22:00" },
                            new OperationHour { Day = "Sunday", OpenTime = "12:00", CloseTime = "22:00" }
                        }.ToJson()
                    },
                    new Resturant
                    {
                        Name = "The Spice Route",
                        Description = "Vibrant Indian restaurant offering a diverse menu of aromatic curries, tandoori specialties, and homemade naan.",
                        CuisineType = "Indian",
                        OperatingHours = new List<OperationHour>
                        {
                            new OperationHour { Day = "Monday", OpenTime = "11:30", CloseTime = "22:30" },
                            new OperationHour { Day = "Tuesday", OpenTime = "11:30", CloseTime = "22:30" },
                            new OperationHour { Day = "Wednesday", OpenTime = "11:30", CloseTime = "22:30" },
                            new OperationHour { Day = "Thursday", OpenTime = "11:30", CloseTime = "22:30" },
                            new OperationHour { Day = "Friday", OpenTime = "11:30", CloseTime = "22:30" },
                            new OperationHour { Day = "Saturday", OpenTime = "11:30", CloseTime = "22:30" },
                            new OperationHour { Day = "Sunday", OpenTime = "11:30", CloseTime = "22:30" }
                        }.ToJson()
                    },
                    new Resturant
                    {
                        Name = "Golden Dragon",
                        Description = "Upscale Chinese restaurant featuring traditional and modern dishes from various regions of China.",
                        CuisineType = "Chinese",
                        OperatingHours = new List<OperationHour>
                        {
                            new OperationHour { Day = "Monday", OpenTime = "11:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Tuesday", OpenTime = "11:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Wednesday", OpenTime = "11:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Thursday", OpenTime = "11:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Friday", OpenTime = "11:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Saturday", OpenTime = "11:00", CloseTime = "23:00" },
                            new OperationHour { Day = "Sunday", OpenTime = "11:00", CloseTime = "23:00" }
                        }.ToJson()
                    },
                    new Resturant
                    {
                        Name = "Mediterranean Oasis",
                        Description = "Relaxed eatery serving fresh Mediterranean dishes with an emphasis on Greek and Lebanese specialties.",
                        CuisineType = "Mediterranean",
                        OperatingHours = new List<OperationHour>
                        {
                            new OperationHour { Day = "Monday", OpenTime = "12:00", CloseTime = "21:30" },
                            new OperationHour { Day = "Tuesday", OpenTime = "Closed", CloseTime = "Closed" },
                            new OperationHour { Day = "Wednesday", OpenTime = "12:00", CloseTime = "21:30" },
                            new OperationHour { Day = "Thursday", OpenTime = "12:00", CloseTime = "21:30" },
                            new OperationHour { Day = "Friday", OpenTime = "12:00", CloseTime = "21:30" },
                            new OperationHour { Day = "Saturday", OpenTime = "12:00", CloseTime = "21:30" },
                            new OperationHour { Day = "Sunday", OpenTime = "12:00", CloseTime = "21:30" }
                        }.ToJson()
                    }
                };

            await dbContext.Resturants.AddRangeAsync(restaurants);
            dbContext.SaveChanges();
        }
    }
}
