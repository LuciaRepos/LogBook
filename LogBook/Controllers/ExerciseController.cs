using LogBook.Data;
using LogBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly LogBookDBContext context;
        public ExerciseController(LogBookDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAll()
        {
            var exercises = await context.Exercises.ToListAsync();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetById(int id)
        {
            var exercise = await context.Exercises.FindAsync(id);
            return exercise is null ? NotFound() : Ok(exercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> Create(Exercise exercise)
        {
            context.Exercises.Add(exercise);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = exercise.ExerciseID }, exercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Exercise updatedExercise)
        {
            if (id != updatedExercise.ExerciseID)
            {
                return BadRequest();
            }

            context.Entry(updatedExercise).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exercise = await context.Exercises.FindAsync(id);
            if (exercise is null)
            {
                return NotFound();
            }
            context.Exercises.Remove(exercise);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
