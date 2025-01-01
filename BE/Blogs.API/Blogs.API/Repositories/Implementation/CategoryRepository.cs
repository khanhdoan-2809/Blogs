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

    public async Task<Category?> GetById(Guid id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);  
    }

    #endregion

    #region Update

    public async Task<Category?> UpdateAsync(Category category)
    {
        var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (existingCategory != null)
        {
            _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
        return null;
    }

    #endregion

    #region delete
    public async Task<Category?> DeleteAsync(Guid id)
    {
        var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if(existingCategory == null)
        {
            return null;
        }

        _dbContext.Categories.Remove(existingCategory);
        await _dbContext.SaveChangesAsync();
        return existingCategory;
    }
    #endregion
}
