using LogBook.Data;
using LogBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogUserController : ControllerBase
    {
        private readonly LogBookDBContext context;
        public LogUserController(LogBookDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogUser>>> GetAll([FromQuery] string? UserID = null, [FromQuery] string? Email = null, [FromQuery] string? UserName= null)
        {
            var logUsers = await context.LogUsers.ToListAsync();

            if(!string.IsNullOrEmpty(UserID))
            {
                logUsers = logUsers.Where(lu => lu.UserID.ToString().Contains(UserID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(Email))
            {
                logUsers = logUsers.Where(lu => lu.Email.ToString().Contains(Email, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(UserName))
            {
                logUsers = logUsers.Where(lu => lu.UserName.ToString().Contains(UserName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(logUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogUser>> GetById(int id)
        {
            var logUser = await context.LogUsers.FindAsync(id);
            return logUser is null ? NotFound() : Ok(logUser);
        }

        [HttpPost]
        public async Task<ActionResult<LogUser>> Create(LogUser logUser)
        {
            context.LogUsers.Add(logUser);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = logUser.UserID }, logUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LogUser updatedLogUser)
        {
            if (id != updatedLogUser.UserID)
            {
                return BadRequest();
            }

            context.Entry(updatedLogUser).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var logUser = await context.LogUsers.FindAsync(id);
            if (logUser is null)
            {
                return NotFound();
            }
            context.LogUsers.Remove(logUser);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
