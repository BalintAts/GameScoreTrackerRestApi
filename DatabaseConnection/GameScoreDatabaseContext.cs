using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection;

public class GameScoreDatabaseContext : DbContext
{
    public GameScoreDatabaseContext(DbContextOptions<GameScoreDatabaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }  
    public DbSet<Score> Scores { get; set; }
}
