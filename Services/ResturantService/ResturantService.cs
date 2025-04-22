using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.DTOs.AuditLog;
using RestaurantMenuManagementService.DTOs.Category;
using RestaurantMenuManagementService.DTOs.Item;
using RestaurantMenuManagementService.DTOs.Resturant;
using RestaurantMenuManagementService.Exceptions;
using RestaurantMenuManagementService.Extensions;
using RestaurantMenuManagementService.Repositories.AuditLogRepository;
using RestaurantMenuManagementService.Repositories.CategoryRepository;
using RestaurantMenuManagementService.Repositories.ItemRepository;
using RestaurantMenuManagementService.Repositories.ResturantRepository;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RestaurantMenuManagementService.Services.ResturantService
{
    public class ResturantService : IResturantService
    {
        private readonly IResturantRepository _resturantRepository;
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ResturantService(IResturantRepository resturantRepository, ICategoryRepository categoryRepository, IItemRepository itemRepository, IAuditLogRepository auditLogRepository, IMapper mapper)
        {
            _resturantRepository = resturantRepository;
            _auditLogRepository = auditLogRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoriesResponseDto> GetCategories(Guid resturantId)
        {
            var resturant = await _resturantRepository.GetByIdAsync(resturantId,resturant=> resturant.Categories);
            if (resturant == null)
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(resturant.Categories);
            return new GetCategoriesResponseDto
            {
                Categories = categoriesDtos,
                ResturantId = resturantId
            };
        }

        public async Task<CreatedCategoryDto> CreateCategory(Guid resturantId, CreateCategoryDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }
            var category = _mapper.Map<Category>(dto);
            category.ResturantId = resturantId;
            await _categoryRepository.AddAsync(category);
            return _mapper.Map<CreatedCategoryDto>(category);
        }


        public async Task DeleteCategory(Guid resturantId, Guid categoryId)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ResourceNotFoundException(categoryId, nameof(Category));
            }
            await _categoryRepository.DeleteAsync(category);
        }
        public async Task<UpdatedCategoryDto> UpdateCategory(Guid resturantId, Guid categoryId, UpdateCategoryDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }

            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ResourceNotFoundException(categoryId, nameof(Category));
            }

            _mapper.Map(dto, category);

            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<UpdatedCategoryDto>(category);
        }

        public async Task<List<ResturantDto>> GetResturants()
        {
            var resturants = await _resturantRepository.ListAllAsync();
            return _mapper.Map<List<ResturantDto>>(resturants);
        }

        public async Task<GetMenuItemsDto> GetMenuItems(Guid resturantId, Guid categoryId)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }

            var category = await _categoryRepository.GetByIdAsync(categoryId,category => category.Items);
            if (category == null)
            {
                throw new ResourceNotFoundException(categoryId, nameof(Category));
            }

            return new GetMenuItemsDto
            {
                CategoryId = categoryId,
                CategoryName = category.Name,
                Items = _mapper.Map<List<ItemDto>>(category.Items)
            };
        }

        public async Task<CreatedItemDto> CreateItem(Guid resturantId, Guid categoryId, CreateItemDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }

            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ResourceNotFoundException(categoryId, nameof(Category));
            }

            var item = _mapper.Map<Item>(dto);
            item.CategoryId = categoryId;
            await _itemRepository.AddAsync(item);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                Timestamp = DateTime.UtcNow,
                Action = "CREATE",
                EntityType = nameof(Item),
                EntityId = item.Id.ToString(),
                EntityName = item.Name,
            });

            return _mapper.Map<CreatedItemDto>(item);    
        }

        public async Task<UpdatedItemDto> UpdateItem(Guid resturantId, Guid categoryId, Guid ItemId, UpdateItemDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }

            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ResourceNotFoundException(categoryId, nameof(Category));
            }

            var item = await _itemRepository.GetByIdAsync(ItemId);
            if (item == null)
            {
                throw new ResourceNotFoundException(ItemId, nameof(Item));
            }

            _mapper.Map(dto, item);
            item.CategoryId = category.Id;  
            await _itemRepository.UpdateAsync(item);

            return _mapper.Map<UpdatedItemDto>(item);
        }

        public async Task<AvailabilityUpdatedItemDto> UpdateItemAvailability(Guid resturantId, Guid categoryId, Guid ItemId, UpdateItemAvailabilityDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }

            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new ResourceNotFoundException(categoryId, nameof(Category));
            }

            var item = await _itemRepository.GetByIdAsync(ItemId);
            if (item == null)
            {
                throw new ResourceNotFoundException(ItemId, nameof(Item));
            }
            var oldVale = item.IsAvailable;
            item.IsAvailable = dto.IsAvailable;
            await _itemRepository.UpdateAsync(item);
            var changes = new Dictionary<string, object>();

            if (oldVale != item.IsAvailable)
            {
                var propChanges = new Dictionary<string, object>
                {
                    ["old"] = oldVale,
                    ["new"] = item.IsAvailable
                };
                changes["IsAvailable"] = propChanges;
            }

            await _auditLogRepository.AddAsync(new AuditLog
            {
                Timestamp = DateTime.UtcNow,
                Action = "UPDATE",
                EntityType = nameof(Item),
                EntityId = item.Id.ToString(),
                EntityName = item.Name,
                Changes = changes.Count > 0 ? JsonSerializer.Serialize(changes) : string.Empty
            });

            var resultDto = _mapper.Map<AvailabilityUpdatedItemDto>(item);
            resultDto.UnavailabilityReason = dto.UnavailabilityReason;
            return resultDto;
        }

        public async Task<CreatedItemsBulkDto> CreateItemsBulk(Guid resturantId, CreateItemsBulkDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category == null)
            {
                throw new ResourceNotFoundException(dto.CategoryId, nameof(Category));
            }

            var items = _mapper.Map<List<Item>>(dto.Items);
            var response = new CreatedItemsBulkDto();

            foreach(var item in items)
            {
                item.CategoryId = category.Id;
                try
                {
                    await _itemRepository.AddAsync(item);
                    response.Items.Add(_mapper.Map<CreatedItemDto>(item));
                    response.Successfull++;
                    await _auditLogRepository.AddAsync(new AuditLog
                    {
                        Timestamp = DateTime.UtcNow,
                        Action = "CREATE",
                        EntityType = nameof(Item),
                        EntityId = item.Id.ToString(),
                        EntityName = item.Name,
                    });
                }
                catch (Exception ex)
                {
                    response.Errors.Add($"Error adding item {item.Name} - {ex.Message}");
                    response.Failed++;
                }
            }
            return response;

        }

        public async Task<AuditLogsResponseDto> GetAuditLogs(Guid resturantId, AuditLogsRequestDto dto)
        {
            if (!await _resturantRepository.ExistsAsync(resturantId))
            {
                throw new ResourceNotFoundException(resturantId, nameof(Resturant));
            }
            var expressionList = new List<Expression<Func<AuditLog, bool>>>();
            if(dto.StartDate.HasValue)
            {
                expressionList.Add(log => log.Timestamp >=  dto.StartDate);
            }

            if (dto.EndDate.HasValue)
            {
                expressionList.Add(log => log.Timestamp <= dto.EndDate);
            }

            var pagedResult = await _auditLogRepository.GetPagedAsync(new Models.PaginationParams
            {
                PageNumber = dto.Page,
                PageSize = dto.PageSize,
            }, expressionList.ToArray());

            return new AuditLogsResponseDto
            {
                Logs = _mapper.Map<List<AuditLogDto>>(pagedResult.Items),
                Page = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
        }
    }
}
