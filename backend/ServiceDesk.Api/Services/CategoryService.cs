namespace ServiceDesk.Api.Services;

using ServiceDesk.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Api.Data;
using ServiceDesk.Api.DTOs.Categories;
using ServiceDesk.Api.Models;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _db;

    public CategoryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<CategoryResponseDto>> GetAllCategoriesAsync()
    {
        return await _db.Categories.Select(category => new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description

        }).ToListAsync();
    }

    public async Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto dto)

    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _db.Categories.Add(category);

        await _db.SaveChangesAsync();


        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description

        };

    }

    public async Task<CategoryResponseDto?> UpdateCategoryAsync(int categoryId, UpdateCategoryDto dto)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);

        if (category == null)
        {
            return null;
        }


        category.Name = dto.Name;
        category.Description = dto.Description;

        await _db.SaveChangesAsync();

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

    }

}

