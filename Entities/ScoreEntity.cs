namespace Entities;

using Interfaces;

public class ScoreEntity (IGame Game, IPlayer Player ): IScore
{
    public IGame Game { get; }

    public IPlayer Player { get; }

    public int ScoreValue { get; }
}
