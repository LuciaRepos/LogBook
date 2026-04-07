using LogBook_V2.Data;
using LogBook_V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook_V2.Controllers
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
        public async Task<ActionResult<IEnumerable<LogSession>>> GetAll()
        {
            var logsessions = await context.LogSessions.ToListAsync();
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
