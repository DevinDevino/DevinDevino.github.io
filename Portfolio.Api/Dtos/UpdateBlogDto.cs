namespace Portfolio.Api.Dtos;

public record UpdateBlogDto(
    string titel,
    string beschrijving,
    DateOnly datum
);