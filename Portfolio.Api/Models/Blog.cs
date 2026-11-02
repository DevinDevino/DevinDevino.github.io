namespace Portfolio.Api.Models;

public class Blog
{
    public int Id{get; set;}

    public required string Titel {get; set;}

    public required string Beschrijving {get; set;}

    public Categorie? Categorie {get; set;}

    public int CategorieId{get; set;}

    public DateOnly datum {get; set;}
}
