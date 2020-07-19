using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Horsey.Data;
using Horsey.Domain;

namespace Horsey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingsController : ControllerBase
    {
        private readonly HorseyContext _context;

        public StandingsController(HorseyContext context)
        {
            _context = context;
        }

        // GET: api/Standings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standing>>> GetStandings()
        {
            return await _context.Standings.ToListAsync();
        }

        // GET: api/Standings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Standing>> GetStanding(int id)
        {
            var standing = await _context.Standings.FindAsync(id);

            if (standing == null)
            {
                return NotFound();
            }

            return standing;
        }

        // PUT: api/Standings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStanding(int id, Standing standing)
        {
            if (id != standing.RaceId)
            {
                return BadRequest();
            }

            _context.Entry(standing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandingExists(id))
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

        // POST: api/Standings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Standing>> PostStanding(Standing standing)
        {
            _context.Standings.Add(standing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StandingExists(standing.RaceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStanding", new { id = standing.RaceId }, standing);
        }

        // DELETE: api/Standings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Standing>> DeleteStanding(int id)
        {
            var standing = await _context.Standings.FindAsync(id);
            if (standing == null)
            {
                return NotFound();
            }

            _context.Standings.Remove(standing);
            await _context.SaveChangesAsync();

            return standing;
        }

        private bool StandingExists(int id)
        {
            return _context.Standings.Any(e => e.RaceId == id);
        }
    }
}
