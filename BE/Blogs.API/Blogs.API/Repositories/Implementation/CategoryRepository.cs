using Blogs.API.Data;
using Blogs.API.Models.Domain;
using Blogs.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Repositories.Implementation;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDBContext _dbContext;

    public CategoryRepository(ApplicationDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    #region Create

    public async Task<Category> CreateAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return category;
    }

    #endregion

    #region Get

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    #endregion

}
