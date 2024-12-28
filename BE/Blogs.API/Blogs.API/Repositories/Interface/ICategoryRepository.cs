using Blogs.API.Models.Domain;

namespace Blogs.API.Repositories.Interface;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
}
