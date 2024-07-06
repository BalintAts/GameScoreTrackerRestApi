namespace GameScoreTrackerRestApi;

using Interfaces;

/// <summary>
/// This class converts customt types to builtin types
/// </summary>
/// <param name="Database"></param>
public class GameScoreManager/*(IMyDatabase _database)*/
{
    private readonly IDatabaseMethods _database;

    public GameScoreManager(IDatabaseMethods myDatabase)
    {
        _database = myDatabase;
    }

    public List<Dictionary<string, string>> GetRecordScoresForGame(string title) =>
        ConvertScores(_database.GetRecordScoresForGame(title));

    public List<Dictionary<string, string>> GetRecordScoresForPlayer(string name) =>
        ConvertScores(_database.GetRecordScoresForPlayer(name));

    public Dictionary<string, string> GetRecordScoreForGameForPlayer(string title, string name)
    {
        var score = _database.GetRecordScoreForPlayerForGame(title, name);
        if (score == null)
        {
            throw new Exception($"No score for game {title} for player {name}");
        }

        return new Dictionary<string, string> {
            { "Player:" , score.Player.Name },
            { "Game:" , score.Game.Title },
            { "Score:" , score.ScoreValue.ToString() }
        };
    }

    private List<Dictionary<string, string>> ConvertScores(List<IScore> scores)
    {
        var simpleScores = new List<Dictionary<string, string>>();
        foreach (IScore score in scores)
        {
            var element = new Dictionary<string, string>
            {
                { "Player:" , score.Player.Name },
                { "Game:" , score.Game.Title },
                { "Score:" , score.ScoreValue.ToString() }
            };
            simpleScores.Add(element);
        }
        return simpleScores;
    }
}
