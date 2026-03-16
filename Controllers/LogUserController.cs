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
    public class LogUserController : ControllerBase
    {
        private readonly LogBookContext _context;

        public LogUserController(LogBookContext context)
        {
            _context = context;
        }

        // GET: api/loguser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogUser>>> GetLogUser()
        {
            return await _context.LogUsers.ToListAsync();
        }

        //GET: api/loguser/1
        [HttpGet("{id}")]
        public async Task<ActionResult<LogUser>> GetLogUser(int id)
        {
            var loguser = await _context.LogUsers.FindAsync(id);
            if (loguser == null)
            {
                return NotFound();
            }
            return loguser;
        }

        //POST: api/loguser
        [HttpPost]
        public async Task<ActionResult<LogUser>> CreateLogUser(LogUser loguser)
        {
            _context.LogUsers.Add(loguser);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLogUser), new { id = loguser.Id }, loguser);
        }

        // PUT: api/user/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogUser(int id, LogUser loguser)
        {
            if (id != loguser.Id)
            {
                return BadRequest();
            }

            _context.Entry(loguser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogUserExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        //DELETE: api/loguser/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogUser(int id)
        {
            var loguser = await _context.LogUsers.FindAsync(id);
            if (loguser == null)
            {
                return NotFound();
            }
            _context.LogUsers.Remove(loguser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogUserExists(int id)
        {
            return _context.LogUsers.Any(u => u.Id == id);
        }
    }
}
