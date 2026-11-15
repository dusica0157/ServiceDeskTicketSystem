namespace ServiceDesk.Api.Services.Interfaces;

using ServiceDesk.Api.DTOs.Categories;
using ServiceDesk.Api.Enums;

public interface ICategoryService
{
    Task<List<CategoryResponseDto>> GetAllCategoriesAsync();

    Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto dto);

    Task<CategoryResponseDto?> UpdateCategoryAsync(int categoryId, UpdateCategoryDto dto);

    Task<CategoryDeleteResult> DeleteCategoryAsync (int ategoryId);
}