using LogBook_V2.Data;
using LogBook_V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly LogBookDBContext context;
        public QuestionController(LogBookDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            var questions = await context.Questions.ToListAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetById(int id)
        {
            var question = await context.Questions.FindAsync(id);
            return question is null ? NotFound() : Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Create(Question question)
        {
            context.Questions.Add(question);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = question.QuestionID }, question);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Question updatedQuestion)
        {
            if (id != updatedQuestion.QuestionID)
            {
                return BadRequest();
            }

            context.Entry(updatedQuestion).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var question = await context.Questions.FindAsync(id);
            if (question is null)
            {
                return NotFound();
            }
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
