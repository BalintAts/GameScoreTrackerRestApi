namespace Entities;

using Interfaces;

public class PlayerEntity(string Name, DateTime BirthDay) : IPlayer
{
    public string Name { get; }

    public DateTime BirthDate { get; }
}
