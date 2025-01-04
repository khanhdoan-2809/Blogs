using Blogs.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace Blogs.API.Data;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions options): base(options) { 
    }

    public DbSet<BlogPostDto> BlogSpots { get; set; }
    public DbSet<Category> Categories { get; set; }
}
