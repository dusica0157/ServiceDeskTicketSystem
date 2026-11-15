namespace ServiceDesk.Api.Services.Interfaces;

using ServiceDesk.Api.DTOs.Categories;


public interface ICategoryService
{
    Task<List<CategoryResponseDto>> GetAllCategoriesAsync();

    Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto dto);

    Task<CategoryResponseDto?> UpdateCategoryAsync(int CategoryId, UpdateCategoryDto dto);
}