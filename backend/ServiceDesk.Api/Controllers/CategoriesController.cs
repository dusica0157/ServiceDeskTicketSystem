namespace ServiceDesk.Api.Controllers;

using ServiceDesk.Api.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Api.Services.Interfaces;
[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{

    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()

    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        return Ok(categories);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
    {
        var response = await _categoryService.CreateCategoryAsync(dto);
        return Ok(response);
    }
    [HttpPut("{categoryId}")]

    public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryDto dto)
    {
        var response = await _categoryService.UpdateCategoryAsync(categoryId, dto);
        if(response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

}