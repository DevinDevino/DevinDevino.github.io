namespace Portfolio.Api.Dtos;

public record BlogDto(
    int id,
    string titel,
    string beschrijving,
    DateOnly datum
);