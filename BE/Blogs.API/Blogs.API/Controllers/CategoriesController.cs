using Blogs.API.Models.Domain;
using Blogs.API.Models.DTOs;
using Blogs.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    #region Get

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();

        var response = new List<CategoryDto>();
        foreach (var category in categories)
        {
            response.Add(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            });
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetAllCategories([FromRoute] Guid categoryId)
    {
        var existingCategory = await _categoryRepository.GetById(categoryId);

        if (existingCategory != null)
        {
            return NotFound();
        }

        var response = new CategoryDto { Id = existingCategory.Id, Name = existingCategory.Name, UrlHandle = existingCategory.UrlHandle };

        return Ok(response);
    }


    #endregion

    #region Post

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
    {
        var category = new Category
        {
            Name = request.Name,
            UrlHandle = request.UrlHandle
        };

        await _categoryRepository.CreateAsync(category);

        var response = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Ok(category);
    }

    #endregion

    #region Put

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDto request)
    {
        var category = new Category
        {
            Id = id,
            Name = request.Name,
            UrlHandle = request.UrlHandle
        };

        category = await _categoryRepository.UpdateAsync(category);

        if (category == null)
        {
            return NotFound();
        }

        var response = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };
        return Ok(response);
    }

    #endregion

    #region Delete


    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
    {
        var category = await _categoryRepository.DeleteAsync(id);
        if (category is null)
        {
            return NotFound();
        }

        var response = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Ok(response);
    }
    #endregion
}