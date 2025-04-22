namespace RestaurantMenuManagementService.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(Guid id,string? name = null):base($"{name ?? "Resource"} with id {id} was not found.")
        {
            
        }
    }
}
