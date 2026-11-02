namespace Portfolio.Api.Dtos;

public record BlogDetailsDto(
    int Id,
    string Titel,
    int CategorieId,
    string Beschrijving,
    DateOnly Datum
);