using Interfaces;

namespace DatabaseConnection;

public class Score : IScore
{
    public int Id { get; set; }
    public int ScoreValue { get; set; }
}
