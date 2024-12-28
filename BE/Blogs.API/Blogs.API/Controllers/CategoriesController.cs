using Blogs.API.Data;
using Blogs.API.Models.Domain;
using Blogs.API.Models.DTOs;
using Blogs.API.Repositories.Implementation;
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

    #region Post

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
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
}
