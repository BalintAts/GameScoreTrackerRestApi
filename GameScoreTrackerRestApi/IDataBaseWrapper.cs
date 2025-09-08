using DatabaseConnection;

namespace GameScoreTrackerRestApi;

public interface IDataBaseWrapper
{
    public List<Score> GetRecordScoresForPlayer(string name);
    public List<Score> GetRecordScoresForGame(string title);
    public Score GetRecordScoreForPlayerForGame(string name, string title);
    public Player GetPlayerName(Score score);
    public Game GetGameTitle(Score score);
}