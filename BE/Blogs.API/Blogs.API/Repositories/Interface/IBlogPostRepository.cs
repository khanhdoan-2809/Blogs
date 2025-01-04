using Blogs.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.API.Repositories.Interface;

public interface IBlogSpotRepository
{
    Task<BlogPostDto> CreateAsync(BlogPostDto blogSpot);

    Task<IEnumerable<BlogPost>> GetAllAsync();
}
