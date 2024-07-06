namespace Interfaces;

public interface IScore
{
    IGame Game { get; }
    IPlayer Player { get; }
    int ScoreValue { get; }
}

