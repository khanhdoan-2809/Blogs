using Azure.Core;
using Blogs.API.Models.Domain;
using Blogs.API.Models.DTOs;
using Blogs.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostsController : ControllerBase
{
    private readonly IBlogSpotRepository _blogSpotRepository;
    public BlogPostsController(IBlogSpotRepository blogSpotRepository)
    {
        _blogSpotRepository = blogSpotRepository;
    }

    #region Post

    [HttpPost]
    public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
    {
        var blogSpot = new BlogPostDto
        {
            Author= request.Author,
            Content = request.Content,
            FeaturedImageUrl = request.FeaturedImageUrl,
            IsVisible = request.IsVisible,
            PublishDate = request.PublishDate,
            ShortDescription = request.ShortDescription,
            Title = request.Title,
            UrlHandle = request.UrlHandle,
        };

        blogSpot = await _blogSpotRepository.CreateAsync(blogSpot);

        var response = new BlogPostDto
        {
            Id = blogSpot.Id,
            Author = blogSpot.Author,
            Content = blogSpot.Content,
            FeaturedImageUrl = blogSpot.FeaturedImageUrl,
            IsVisible = blogSpot.IsVisible,
            PublishDate = blogSpot.PublishDate,
            ShortDescription = blogSpot.ShortDescription,
            Title = blogSpot.Title,
            UrlHandle = blogSpot.UrlHandle,
        };

        return Ok(response);
    }

    #endregion

    #region Get

    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
        var blogPost = await _blogSpotRepository.GetAllAsync();

        var response = new List<BlogPostDto>();
        foreach(var blogPost in blogPosts)
        {
            response.Add(new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishDate = blogPost.PublishDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle
            });
        }

        return Ok(response);
    }

    #endregion
}