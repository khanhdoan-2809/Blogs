using Blogs.API.Data;
using Blogs.API.Models.Domain;
using Blogs.API.Repositories.Interface;

namespace Blogs.API.Repositories.Implementation;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDBContext _dbContext;

    public CategoryRepository(ApplicationDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<Category> CreateAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        return category;
    }
}
