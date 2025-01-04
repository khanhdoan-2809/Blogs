using Blogs.API.Data;
using Blogs.API.Models.Domain;
using Blogs.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blogs.API.Repositories.Implementation;

public class BlogPostRepository : IBlogSpotRepository
{
    private readonly ApplicationDBContext _dbContext;

    public BlogPostRepository(ApplicationDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    #region Create

    public async Task<BlogPostDto> CreateAsync(BlogPostDto blogPost)
    {
        await _dbContext.BlogSpots.AddAsync(blogPost);
        await _dbContext.SaveChangesAsync();

        return blogPost;
    }

    #endregion

}
