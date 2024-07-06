namespace Entities;

using Interfaces;

public class GameEntitiy(string Title, string Genre) : IGame
{
    public string Title { get; }

    public string Genre { get; }
}
