using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Zadania.Models;

namespace Zadania.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Root> Roots { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<EntityPersonWspolnik> EntityPersonWspolniks { get; set; }
        public DbSet<EntityPersonProkurent> EntityPersonProkurents { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<TaskEntry> Tasks { get; set; }
        public DbSet<MovieText> MovieTexts { get; set; }

        
        public DatabaseContext(DbContextOptions options) :base(options)
        {
            
            
        }
    }
}
