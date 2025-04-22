using System.Text.Json;
using System.Text;

namespace RestaurantMenuManagementService.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions DefaultOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static async Task<T?> FromJsonAsync<T>(this string json, T? defaultVal = default, JsonSerializerOptions? options = null)
        {
            if (string.IsNullOrEmpty(json)) return defaultVal;

            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return await JsonSerializer.DeserializeAsync<T>(memoryStream, options ?? DefaultOptions) ?? defaultVal;
        }

        public static T? FromJson<T>(this string json, T? defaultVal = default, JsonSerializerOptions? options = null)
        {
            if (string.IsNullOrEmpty(json)) return defaultVal;
            return JsonSerializer.Deserialize<T>(json, options ?? DefaultOptions) ?? defaultVal;
        }

        public static async Task<string> ToJsonAsync(this object obj, JsonSerializerOptions? options = null)
        {
            using var memoryStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memoryStream, obj, options ?? DefaultOptions);
            memoryStream.Position = 0;
            using var reader = new StreamReader(memoryStream);
            return await reader.ReadToEndAsync();
        }

        public static string ToJson(this object obj, JsonSerializerOptions? options = null, string defaultVal = "{}")
        {
            if (obj == null) return defaultVal;
            return JsonSerializer.Serialize(obj, options ?? DefaultOptions) ?? defaultVal;
        }
    }
}
