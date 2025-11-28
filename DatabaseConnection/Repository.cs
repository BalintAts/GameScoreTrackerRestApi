using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection;

public class Repository 
{
    private readonly GameScoreDatabaseContext _dataContext;

    public Repository(GameScoreDatabaseContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Game>> GetGames(CancellationToken ct) => await _dataContext.Games.ToListAsync(ct);

    public async Task<List<Player>> GetPlayers(CancellationToken ct) => await _dataContext.Players.ToListAsync(ct);

    public async Task<Player> GetPlayerForName(string name, CancellationToken ct)
    {
        return await _dataContext.Players.FirstOrDefaultAsync(p => p.Name.ToLower().Equals(name.ToLower()), ct);   // ?? NullEntity with fields
    }

    public async Task<Game> GetGameForTitle(string title, CancellationToken ct)
    {
        return await _dataContext.Games.FirstOrDefaultAsync(g => g.Title.ToLower().Equals( title.ToLower()), ct);
    }

    public async Task<List<Score>> GetScoresForPlayer(string name, CancellationToken ct)
    {
        return await _dataContext.Scores.Include(s => s.Player).Include(s => s.Game).Where(s => s.Player.Name.ToLower().Equals(name.ToLower())).ToListAsync(ct);
    }

    public async Task<List<Score>> GetScoresForGame(string title, CancellationToken ct)
    {
        return await _dataContext.Scores.Include(s => s.Game).Include(s => s.Player).Where(s => s.Game.Title.ToLower().Equals(title.ToLower())).ToListAsync(ct);
    }

    public async Task<Score> GetScoreForPlayerAndGame(string name, string title,CancellationToken ct)
    {
        return await _dataContext.Scores.Include(s => s.Player)
            .Include(s => s.Game)
            .FirstOrDefaultAsync(s => s.Player.Name.ToLower().Equals (name.ToLower()) && s.Game.Title.ToLower()
         .Equals (title.ToLower()), ct);
    }

    public async Task AddPlayer(Player player, CancellationToken ct)
    {
        _dataContext.Players.Add(player);
        await _dataContext.SaveChangesAsync(ct);
    }

    public async Task AddGame(Game game, CancellationToken ct)
    {
        _dataContext.Games.Add(game);
        await _dataContext.SaveChangesAsync(ct);
    }

    public async Task AddScore(Score score, CancellationToken ct)
    {
        _dataContext.Scores.Add(score);
        await _dataContext.SaveChangesAsync(ct);
    }

    public async Task ChangeGenre(string title, string genre, CancellationToken ct)
    {
        var game = await GetGameForTitle(title, ct);
        if (game != null)
        {
            game.Genre = genre;
        }
        await _dataContext.SaveChangesAsync();

    }
}
