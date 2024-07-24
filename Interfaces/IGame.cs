namespace Interfaces;

//these are useful, so other project can use other dto-s
public interface IGame  
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
}
