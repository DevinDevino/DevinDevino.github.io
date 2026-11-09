using Portfolio.Api.Data;
using Portfolio.Api.Dtos;
using Portfolio.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Api.Endpoints;

public static class BlogEndpoints
{
    const string GetBlogEndpointName = "GetBlog";
    const string GetSqliteBlogEndpointName = "GetSqliteBlog";


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

    // De code heeft voor nu nog een 
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
        group.MapPost("/", (CreateBlogDto newBlog) =>
        {
            var blog = new BlogDto(
                blogs.Count == 0 ? 1 : blogs.Max(blog => blog.Id) + 1,
                newBlog.Titel,
                newBlog.Categorie,
                newBlog.Beschrijving,
                newBlog.Datum
            );

            blogs.Add(blog);
            return Results.CreatedAtRoute(GetBlogEndpointName, new { id = blog.Id }, blog);
        });

        //GET /blog/sqlite
        group.MapGet("/sqlite", async (BlogContext dbContext) =>
            await dbContext.Blogs
                .OrderBy(blog => blog.Id)
                .Select(blog => new BlogDetailsDto(
                    blog.Id,
                    blog.Titel,
                    blog.CategorieId,
                    blog.Beschrijving,
                    blog.datum))
                .ToListAsync());

        //GET /blog/sqlite/{id}
        group.MapGet("/sqlite/{id:int}", async (int id, BlogContext dbContext) =>
        {
            var blog = await dbContext.Blogs
                .Where(blog => blog.Id == id)
                .Select(blog => new BlogDetailsDto(
                    blog.Id,
                    blog.Titel,
                    blog.CategorieId,
                    blog.Beschrijving,
                    blog.datum))
                .FirstOrDefaultAsync();

            return blog is null ? Results.NotFound() : Results.Ok(blog);
        })
        .WithName(GetSqliteBlogEndpointName);

        //POST /blog/sqlite
        group.MapPost("/sqlite", async (CreateSqliteBlogDto newBlog, BlogContext dbContext) =>
        {
            var categoryExists = await dbContext.Set<Categorie>()
                .AnyAsync(category => category.Id == newBlog.CategorieId);

            if (!categoryExists)
            {
                return Results.BadRequest($"Categorie {newBlog.CategorieId} bestaat niet.");
            }

            var blog = new Blog
            {
                Titel = newBlog.Titel,
                CategorieId = newBlog.CategorieId,
                Beschrijving = newBlog.Beschrijving,
                datum = newBlog.Datum
            };

            dbContext.Blogs.Add(blog);
            await dbContext.SaveChangesAsync();

            var blogDto = new BlogDetailsDto(
                blog.Id,
                blog.Titel,
                blog.CategorieId,
                blog.Beschrijving,
                blog.datum);

            return Results.CreatedAtRoute(GetSqliteBlogEndpointName, new { id = blog.Id }, blogDto);
        });

        //PUT /blog/sqlite/{id}
        group.MapPut("/sqlite/{id:int}", async (int id, UpdateSqliteBlogDto updateBlog, BlogContext dbContext) =>
        {
            var blog = await dbContext.Blogs.FindAsync(id);
            if (blog is null)
            {
                return Results.NotFound();
            }

            var categoryExists = await dbContext.Set<Categorie>()
                .AnyAsync(category => category.Id == updateBlog.CategorieId);

            if (!categoryExists)
            {
                return Results.BadRequest($"Categorie {updateBlog.CategorieId} bestaat niet.");
            }

            blog.Titel = updateBlog.Titel;
            blog.CategorieId = updateBlog.CategorieId;
            blog.Beschrijving = updateBlog.Beschrijving;
            blog.datum = updateBlog.Datum;

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        //DELETE /blog/sqlite/{id}
        group.MapDelete("/sqlite/{id:int}", async (int id, BlogContext dbContext) =>
        {
            var blog = await dbContext.Blogs.FindAsync(id);
            if (blog is null)
            {
                return Results.NotFound();
            }

            dbContext.Blogs.Remove(blog);
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
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
