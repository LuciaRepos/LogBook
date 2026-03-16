using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogBookAPI.Data;
using System.Collections.Generic;
using System.Linq;
using LogBookAPI.Models;

namespace LogBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogSessionController : ControllerBase
    {
        private readonly LogBookContext _context;
        public LogSessionController(LogBookContext context)
        {
            _context = context;
        }

        // GET: api/logsession
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogSession>>> GetLogSession()
        {
            return await _context.LogSessions.ToListAsync();
        }

        // GET: api/logsession/1
        [HttpGet("{id}")]
        public async Task<ActionResult<LogSession>> GetLogSession(int id)
        {
            var logsession = await _context.LogSessions.FindAsync(id);
            if (logsession == null)
            {
                return NotFound();
            }
            return logsession;
        }

        // POST: api/logsession
        [HttpPost]
        public async Task<ActionResult<LogSession>> CreateLogSession(LogSession logsession)
        {
            _context.LogSessions.Add(logsession);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLogSession), new {id = logsession.Id},  logsession);
        }

        // PUT: api/logsession/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogSession(int id, LogSession logsession)
        {
            if (id != logsession.Id)
            {
                return BadRequest();
            }

            _context.Entry(logsession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogSessionExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE: api/logsession/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogSession(int id)
        {
            var logsession = await _context.LogSessions.FindAsync(id);
            if (logsession == null)
            {
                return NotFound();
            }

            _context.LogSessions.Remove(logsession);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool LogSessionExists(int id)
        {
            return _context.LogSessions.Any(s => s.Id == id);
        }
    }
}
