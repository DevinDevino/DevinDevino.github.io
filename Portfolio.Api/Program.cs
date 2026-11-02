using Portfolio.Api.Data;
using Portfolio.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddBlogDb();

var app = builder.Build();

app.MapBlogEndpoints();

app.MigrateDb();

app.Run();
