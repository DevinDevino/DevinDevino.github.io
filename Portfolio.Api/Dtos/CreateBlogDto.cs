namespace Portfolio.Api.Dtos;

public record CreateBlogDto(
    string titel,
    string beschrijving,
    DateOnly datum
);