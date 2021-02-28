using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using songlistApi.Data;
using songlistApi.Models;

namespace songlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class SonglistController : ControllerBase
    {
        private readonly SonglistContext _context;

        public SonglistController(SonglistContext context)
        {
            _context = context;
        }

        // GET: api/Songlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songlist>>> GetSonglist()
        {
            return await _context.Songlist.ToListAsync();
        }

        // GET: api/Songlist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songlist>> GetSonglist(int id)
        {
            var songlist = await _context.Songlist.FindAsync(id);

            if (songlist == null)
            {
                return NotFound();
            }

            return songlist;
        }

        // PUT: api/Songlist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSonglist(int id, Songlist songlist)
        {
            if (id != songlist.SongId)
            {
                return BadRequest();
            }

            _context.Entry(songlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SonglistExists(id))
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

        // POST: api/Songlist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Songlist>> PostSonglist(Songlist songlist)
        {
            _context.Songlist.Add(songlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSonglist", new { id = songlist.SongId }, songlist);
        }

        // DELETE: api/Songlist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSonglist(int id)
        {
            var songlist = await _context.Songlist.FindAsync(id);
            if (songlist == null)
            {
                return NotFound();
            }

            _context.Songlist.Remove(songlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SonglistExists(int id)
        {
            return _context.Songlist.Any(e => e.SongId == id);
        }
    }
}
