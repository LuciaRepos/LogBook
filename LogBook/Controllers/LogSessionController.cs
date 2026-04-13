using LogBook.Data;
using LogBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogSessionController : ControllerBase
    {
        private readonly LogBookDBContext context;
        public LogSessionController(LogBookDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogSession>>> GetAll([FromQuery] string? SessionID = null, [FromQuery] string? SessionDate = null, [FromQuery] string? DurationMinutes = null, [FromQuery] string? SessionDescription = null)
        {
            var logsessions = await context.LogSessions.ToListAsync();

            if(!string.IsNullOrEmpty(SessionID))
            {
                logsessions = logsessions.Where(ls => ls.SessionID.ToString().Contains(SessionID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(SessionDate))
            {
                logsessions = logsessions.Where(ls => ls.SessionDate.ToString().Contains(SessionDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(DurationMinutes))
            {
                logsessions = logsessions.Where(ls => ls.DurationMinutes.ToString().Contains(DurationMinutes, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(SessionDescription))
            {
                logsessions = logsessions.Where(ls => ls.SessionDescription.ToString().Contains(SessionDescription, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(logsessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogSession>> GetById(int id)
        {
            var logSession = await context.LogSessions.FindAsync(id);
            return logSession is null ? NotFound() : Ok(logSession);
        }

        [HttpPost]
        public async Task<ActionResult<LogSession>> Create(LogSession logSession)
        {
            context.LogSessions.Add(logSession);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = logSession.SessionID }, logSession);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LogSession updatedLogSession)
        {
            if (id != updatedLogSession.SessionID)
            {
                return BadRequest();
            }

            context.Entry(updatedLogSession).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var logsession = await context.LogSessions.FindAsync(id);
            if (logsession is null)
            {
                return NotFound();
            }
            context.LogSessions.Remove(logsession);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
