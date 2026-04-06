using LogBook_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace LogBook_V2.Data
{
    public class LogBookDBContext(DbContextOptions<LogBookDBContext> options) : DbContext(options)
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<LogUser> LogUsers { get; set; }
        public DbSet<LogSession> LogSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}