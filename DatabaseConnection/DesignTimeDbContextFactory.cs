using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatabaseConnection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameScoreDatabaseContext>
{
    public GameScoreDatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GameScoreDatabaseContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=GameScoreDb;Trusted_Connection=True;");
        return new GameScoreDatabaseContext(optionsBuilder.Options);
    }
}