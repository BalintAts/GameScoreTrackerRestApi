using DatabaseConnection;
using GameScoreTrackerRestApi.ViewModels;

namespace GameScoreTrackerRestApi;


/// <summary>
/// This class converts custom types/entities to builtin types
/// </summary>
/// <param name="Database"></param>
public class GameScoreManager
{
    private readonly Repository _repository;

    public GameScoreManager(Repository repo)
    {
        _repository = repo;
    }

    public async Task<List<string>> GetGameTitles(CancellationToken ct)
    {
        var games = await _repository.GetGames(ct);
        return games.Select(x => x.Title).ToList();
    }

    public async Task<List<string>> GetPlayerNames(CancellationToken ct)
    {
        var players = await _repository.GetPlayers(ct);
        return players.Select(x => x.Name).ToList();
    }

    public async Task<List<ScoreVM>> GetScoresForGame(string Title, CancellationToken ct)
    {
        var scores = await _repository.GetScoresForGame(Title, ct);

        return scores.Select(
            x => new ScoreVM
            {
                PlayerName = x.Player.Name,
                GammeTitle = x.Game.Title,
                Score = x.ScoreValue
            }
        ).ToList();
    }

    public async Task<List<ScoreVM>> GetScoresForPlayer(string Name, CancellationToken ct)
    {
        var scores = await _repository.GetScoresForPlayer(Name, ct);

        return scores.Select(
            x => new ScoreVM
                {
                    PlayerName = x.Player.Name,
                    GammeTitle = x.Game.Title,
                    Score = x.ScoreValue
                }
            ).ToList();
    }

    public async Task<ScoreVM> GetScoreForPlayerAndGame(string name, string title, CancellationToken ct)
    {
        var score = await _repository.GetScoreForPlayerAndGame(name, title, ct);
        if (score == null)
        {
            return null;
        }

        return new ScoreVM
        {
            PlayerName = score.Player.Name,
            GammeTitle = score.Game.Title,
            Score = score.ScoreValue
        };
    }

    public async Task AddPlayer(PlayerVM player, CancellationToken ct)
    {
        var playerEntity = new Player { Name = player.Name, Birthdate = DateTime.Today };
        await _repository.AddPlayer(playerEntity, ct);
    }

    public async Task AddGame(GameVM game, CancellationToken ct)
    {
        var gameEntity = new Game { Title = game.Title , Genre = game.Genre };
        await _repository.AddGame(gameEntity, ct);
    }

    public async Task AddScore(ScoreVM score, CancellationToken ct)
    {
        var player = await _repository.GetPlayerForName(score.PlayerName, ct);
        var game = await _repository.GetGameForTitle(score.GammeTitle, ct);
        var scoreEntity = new Score { Player = player, Game = game };
        await _repository.AddScore(scoreEntity, ct);
    }

    public async Task ChangeGenre(string title, string genre, CancellationToken ct)
    {
        await _repository.ChangeGenre(title, genre, ct);
    }
}
