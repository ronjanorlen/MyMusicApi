using System.ComponentModel.DataAnnotations; // Stöd för DataAnnotations

namespace MyMusicApi.Models;

public class Song
{
    // Properties 
    public int Id { get; set; } // Primärnyckel 
    // Artist
    [Required(ErrorMessage = "Ange artist")]
    public string? Artist { get; set; }

    // Låttitel
    [Required(ErrorMessage = "Ange titel på låten")]
    public string? Title { get; set; }

    // Låtlängd
    public int Length { get; set; }

    // Kategori
    [Required(ErrorMessage = "Ange vilken kategori låten tillhör")]
    public string? Category { get; set; }
}