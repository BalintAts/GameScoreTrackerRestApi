namespace DatabaseConnection;

public class Player /*: IPlayer*/
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Score> Scores { get; set; }

    public DateTime Birthdate { get; set; }
}
