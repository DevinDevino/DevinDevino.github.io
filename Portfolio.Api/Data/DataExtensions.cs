using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Models;

namespace Portfolio.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
        dbContext.Database.Migrate();
    }

    public static void AddBlogDb(this WebApplicationBuilder builder)
    {
        var conString = builder.Configuration.GetConnectionString("Blog");
        
        builder.Services.AddSqlite<BlogContext>(conString, optionsAction: options => options.UseSeeding((context, _) =>
        {
            if (!context.Set<Categorie>().Any())
            {
                context.Set<Categorie>().AddRange(
                    new Categorie { Naam = "Leren" },
                    new Categorie { Naam = "Nakijken" },
                    new Categorie { Naam = "Coderen" },
                    new Categorie { Naam = "Werken aan Database" },
                    new Categorie { Naam = "Sporten" }
                );

                context.SaveChanges();
            }
        }));
    }
}
