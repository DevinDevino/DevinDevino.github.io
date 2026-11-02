using Portfolio.Api.Data;
using Portfolio.Api.Dtos;
using Portfolio.Api.Models;

namespace Portfolio.Api.Endpoints;

public static class BlogEndpoints
{
    const string GetBlogEndpointName = "GetBlog";


    private static readonly List<BlogDto> blogs =
    [
        new BlogDto(
        1,
        "Mijn eerste blog",
        "Leren",
        "Dit is mijn eerste blogbericht.",
        new DateOnly(2023, 1, 1)
    ),

    new BlogDto(
        2,
        "Mijn tweede blog",
        "Coderen",
        "Dit is mijn tweede blogbericht.",
        new DateOnly(2023, 2, 1)
    ),

    new BlogDto(
        3,
        "Mijn derde blog",
        "Nakijken",
        "Dit is mijn derde blogbericht.",
        new DateOnly(2023, 3, 1)
    )
    ];

    public static void MapBlogEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/blog");

        // GET /blog
        group.MapGet("/", () => blogs);

        //Get /blog/{id}
        group.MapGet("/{id}", (int id) =>
        {
            var blog = blogs.Find(blog => blog.Id == id);

            return blog is null ? Results.NotFound() : Results.Ok(blog);
        })

        .WithName(GetBlogEndpointName);

        //POST /blog
        group.MapPost("/", (CreateBlogDto newBlog, BlogContext dbContext) =>
        {
            Blog blog = new()
            {
                Titel = newBlog.Titel,
                CategorieId = newBlog.CategorieID,
                Beschrijving = newBlog.Beschrijving,
                datum = newBlog.Datum
            };
            
            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();

            BlogDetailsDto blogDto = new(
                blog.Id,
                blog.Titel,
                blog.CategorieId,
                blog.Beschrijving,
                blog.datum
            );

            return Results.CreatedAtRoute(GetBlogEndpointName, new { id = blog.Id }, blog);
        });


        //PUT /blog/1
        group.MapPut("/{id}", (int id, UpdateBlogDto updateBlog) =>
        {
            var index = blogs.FindIndex(blog => blog.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            blogs[index] = new BlogDto
            (
                id,
                updateBlog.Titel,
                updateBlog.Categorie,
                updateBlog.Beschrijving,
                updateBlog.Datum
            );

            return Results.NoContent();
        });


        //DELETE /blog/1
        group.MapDelete("/{id}", (int id) =>
        {
            blogs.RemoveAll(blogs => blogs.Id == id);

            return Results.NoContent();


        });
    }
}
