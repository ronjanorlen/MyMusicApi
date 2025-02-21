using Microsoft.EntityFrameworkCore;
using MyMusicApi.Models;

namespace MyMusicApi.Data;

public class MusicDbContext : DbContext {
    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { } // konstruktor

    // Tabell i databas 
    public DbSet<Song> Songs { get; set; }
}