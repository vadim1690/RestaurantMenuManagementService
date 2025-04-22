namespace RestaurantMenuManagementService.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmptyString(this string? value) =>
            string.IsNullOrEmpty(value);
    }
}
