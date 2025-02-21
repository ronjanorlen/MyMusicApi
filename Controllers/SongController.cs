using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicApi.Data;
using MyMusicApi.Models;

namespace MyMusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // Anslutning till databas 
        private readonly MusicDbContext _context;

        public SongController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync(); // Returnera alla låtar som lista
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id) 
        // Kontrollera om låt finns i databas baserat på id 
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null) // Om låten inte finns 
            {
                return NotFound();
            }

            return song; // Returnera låt 
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song) // Uppdatera låt
        {
            // Kontrollera att id är korrekt 
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified; // Lägg i kö för uppdatering

            // Uppdatera 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Songs.Add(song); // Lägg till ny låt 
            await _context.SaveChangesAsync(); // Spara ändringar

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id) // Ta bort låt 
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
