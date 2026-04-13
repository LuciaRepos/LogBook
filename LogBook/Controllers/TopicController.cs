using LogBook.Data;
using LogBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly LogBookDBContext context;
        public TopicController(LogBookDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAll([FromQuery] string? TopicID = null, [FromQuery] string? Theme = null, [FromQuery] string? Content = null)
        {
            var topics = await context.Topics.ToListAsync();

            if (!string.IsNullOrEmpty(TopicID))
            {
                topics = topics.Where(t => t.TopicID.ToString().Contains(TopicID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(Theme))
            {
                topics = topics.Where(t => t.Theme.Contains(Theme, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(Content))
            {
                topics = topics.Where(t => t.Content.Contains(Content, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetById(int id)
        {
            var topic = await context.Topics.FindAsync(id);
            return topic is null ? NotFound() : Ok(topic);
        }

        [HttpPost]
        public async Task<ActionResult<Topic>> Create(Topic topic)
        {
            context.Topics.Add(topic);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = topic.TopicID }, topic);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Topic updatedTopic)
        {
            if (id != updatedTopic.TopicID)
            {
                return BadRequest();
            }

            context.Entry(updatedTopic).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var topic = await context.Topics.FindAsync(id);
            if (topic is null)
            {
                return NotFound();
            }
            context.Topics.Remove(topic);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
