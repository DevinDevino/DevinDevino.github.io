namespace Portfolio.Api.Dtos;

public record BlogDto(
    int Id,
    string Titel,
    string Categorie,
    string Beschrijving,
    DateOnly Datum
);