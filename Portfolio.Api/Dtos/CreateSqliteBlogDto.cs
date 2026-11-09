using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Dtos;

public record CreateSqliteBlogDto(
    [Required][StringLength(50)] string Titel,
    [Range(1, int.MaxValue)] int CategorieId,
    [Required] string Beschrijving,
    DateOnly Datum
);
