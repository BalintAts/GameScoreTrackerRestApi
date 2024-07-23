namespace Interfaces;

public interface IDataBaseWrapper
{
    public List<IScore> GetRecordScoresForPlayer(string name);
    public List<IScore> GetRecordScoresForGame(string title);
    public IScore GetRecordScoreForPlayerForGame(string name, string title);
}

