using DatabaseConnection;
using GameScoreTrackerRestApi.ViewModels;

namespace GameScoreTrackerRestApi;


/// <summary>
/// This class converts customt types/entities to builtin types
/// </summary>
/// <param name="Database"></param>
public class GameScoreManager
{
    private readonly Repository _repsoritory;

    public GameScoreManager(Repository repo)
    {
        _repsoritory = repo;
    }

    public List<string> GetGameTitles()
    {
        var games = _repsoritory.GetGames();
        return games.Select(x => x.Title).ToList();
    }

    public List<string> GetPlayerNames()
    {
        var players = _repsoritory.GetPlayers();
        return players.Select(x => x.Name).ToList();
    }

    public List<ScoreVM> GetScoresForGame(string Title)
    {
        var scores = _repsoritory.GetScoresForGame(Title).ToList();

        return scores.Select(
            x => new ScoreVM
            {
                PlayerName = x.Player.Name,
                GammeTitle = x.Game.Title,
                Score = x.ScoreValue
            }
        ).ToList();
    }

    public List<ScoreVM> GetScoresForPlayer(string Name)
    {
        var scores = _repsoritory.GetScoresForPlayer(Name).ToList();

        return scores.Select(
            x => new ScoreVM
                {
                    PlayerName = x.Player.Name,
                    GammeTitle = x.Game.Title,
                    Score = x.ScoreValue
                }
            ).ToList();
    }

    public ScoreVM GetScoreForPlayerAndGame(string name, string title)
    {
        var score = _repsoritory.GetScoreForPlayerAndGame(name, title);
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

    public void AddPlayer(PlayerVM player)
    {
        var playerEntity = new Player { Name = player.Name, Birthdate = DateTime.Today };
        _repsoritory.AddPlayer(playerEntity);
    }

    public void AddGame(GameVM game)
    {
        var gameEntity = new Game { Title = game.Title , Genre = game.Genre };
        _repsoritory.AddGame(gameEntity);
    }

    public void AddScore(ScoreVM score)
    {
        var player = _repsoritory.GetPlayerForName(score.PlayerName);
        var game = _repsoritory.GetGameForTitle(score.GammeTitle);
        var scoreEntity = new Score { Player = player, Game = game };
        _repsoritory.AddScore(scoreEntity);
    }

    public void ChangeGenre(string title, string genre)
    {
        _repsoritory.ChangeGenre(title, genre);
    }
}
