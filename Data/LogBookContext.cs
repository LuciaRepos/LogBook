using LogBookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace LogBookAPI.Data;
public class LogBookContext : DbContext

{
    public LogBookContext(DbContextOptions<LogBookContext> options) : base(options)
    {
    }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<LogUser> LogUsers { get; set; }
        public DbSet<LogSession> LogSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Question> Questions { get; set; }
}
