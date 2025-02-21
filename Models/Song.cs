using System.ComponentModel.DataAnnotations; // Stöd för DataAnnotations

namespace MyMusicApi.Models;

public class Song
{
    // Properties 
    public int Id { get; set; } // Primärnyckel 
    // Artist
    [Required]
    public string? Artist { get; set; }

    // Låttitel
    [Required]
    public string? Title { get; set; }

    // Låtlängd
    public int Length { get; set; }

    // Kategori
    [Required]
    public string? Category { get; set; }
}