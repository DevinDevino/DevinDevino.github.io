using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Dtos;

public record CreateBlogDto(
    [Required][StringLength(50)] string Titel,
    [Range (1,50)] int CategorieID,
    [Required] string Beschrijving,
    DateOnly Datum
);