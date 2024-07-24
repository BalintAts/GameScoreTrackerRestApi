using Interfaces;

namespace DatabaseConnection;

public class Player : IPlayer
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public DateTime Birthdate { get; set; }
}
