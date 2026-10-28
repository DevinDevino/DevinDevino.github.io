using Portfolio.Api.Dtos;

const string GetBlogEndpointName = "GetBlog";

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<BlogDto> blogs =
[
    new BlogDto(
        1, 
        "Mijn eerste blog",
        "Dit is mijn eerste blogbericht.",
        new DateOnly(2023, 1, 1)
    ),

    new BlogDto(
        2, 
        "Mijn tweede blog",
        "Dit is mijn tweede blogbericht.",
        new DateOnly(2023, 2, 1)
    ),

    new BlogDto(
        3, 
        "Mijn derde blog",
        "Dit is mijn derde blogbericht.",
        new DateOnly(2023, 3, 1)
    )
];

// GET /blog
app.MapGet("/blog", () => blogs);

//Get /blog/{id}
app.MapGet("/blog/{id}", (int id) => blogs.Find(blog => blog.id == id))
    .WithName(GetBlogEndpointName);

//POST /blog
app.MapPost("/blog", (CreateBlogDto createBlogDto) =>
{
    BlogDto blog = new(
        blogs.Count + 1,
        createBlogDto.titel,
        createBlogDto.beschrijving,
        createBlogDto.datum
    );
    blogs.Add(blog);
    return Results.CreatedAtRoute(GetBlogEndpointName, new {id = blog.id}, blog);
});


//PUT /blog/1
app.MapPut("/blog/{id}", (int id, UpdateBlogDto updateBlog) =>
{
    var index = blogs.FindIndex(blog => blog.id == id);

    blogs[index] = new BlogDto
    (
        id,
        updateBlog.titel,
        updateBlog.beschrijving,
        updateBlog.datum
    );

    return Results.NoContent();
});


//DELETE /blog/1
app.MapDelete("/blog/{id}", (int id) =>
{
    blogs.RemoveAll(blogs => blogs.id == id);

    return Results.NoContent();


});

app.Run();
