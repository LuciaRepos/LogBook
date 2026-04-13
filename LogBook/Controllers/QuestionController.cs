using LogBook.Data;
using LogBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Controllers
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
        public async Task<ActionResult<IEnumerable<Question>>> GetAll([FromQuery] string? QuestionID = null, [FromQuery] string? QuestionStatement = null, [FromQuery] string? QuestionDate = null, [FromQuery] string? AnswerDate = null, [FromQuery] string? Answer = null)
        {
            var questions = await context.Questions.ToListAsync();

            if(!string.IsNullOrEmpty(QuestionID))
            {
                questions = questions.Where(q => q.QuestionID.ToString().Contains(QuestionID, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(QuestionStatement))
            {
                questions = questions.Where(q => q.QuestionStatement.ToString().Contains(QuestionStatement, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(QuestionDate))
            {
                questions = questions.Where(q => q.QuestionDate.ToString().Contains(QuestionDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(AnswerDate))
            {
                questions = questions.Where(q => q.AnswerDate.ToString().Contains(AnswerDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(Answer))
            {
                questions = questions.Where(q => q.Answer != null && q.Answer.Contains(Answer , StringComparison.OrdinalIgnoreCase)).ToList();
            }

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
