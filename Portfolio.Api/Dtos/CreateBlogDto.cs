using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Dtos;

public record CreateBlogDto(
    [Required][StringLength(50)] string Titel,
    [Required][StringLength(50)] string Categorie,
    [Required] string Beschrijving,
    DateOnly Datum
);
