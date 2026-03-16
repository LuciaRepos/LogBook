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
    public class QuestionController : ControllerBase
    {
        private readonly LogBookContext _context;
        
        public QuestionController(LogBookContext context)
        {
            _context = context;
        }

        // GET: api/question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            return await _context.Questions.ToListAsync();
        }

        // GET: api/question/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync();
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

        // POST: api/question
        [HttpPost]
        public async Task<ActionResult<Question>> CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        // PUT: api/question/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE: api/question/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(q => q.Id == id);
        }
    }
}
