using Microsoft.EntityFrameworkCore;
using RestaurantMenuManagementService.Data;
using RestaurantMenuManagementService.Middlewares;
using RestaurantMenuManagementService.Repositories.AuditLogRepository;
using RestaurantMenuManagementService.Repositories.CategoryRepository;
using RestaurantMenuManagementService.Repositories.ItemRepository;
using RestaurantMenuManagementService.Repositories.ResturantRepository;
using RestaurantMenuManagementService.Services.ResturantService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ResturantMenuManagementDB"));

builder.Services.AddScoped<IResturantRepository, ResturantRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IResturantService, ResturantService>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Data seed
await SeedData.InitializeAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
