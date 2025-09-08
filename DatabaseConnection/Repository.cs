using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseConnection;

public class Repository 
{
    private readonly GameScoreDatabaseContext _dataContext;

    public Repository(GameScoreDatabaseContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Game> GetGames() => _dataContext.Games.ToList();

    public List<Player> GetPlayers() => _dataContext.Players.ToList();

    public Player GetPlayerForName(string name)
    {
        return _dataContext.Players.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());   // ?? NullEntity with fields
    }

    public Game GetGameForTitle(string title)
    {
        return _dataContext.Games.FirstOrDefault(g => g.Title.ToLower() == title.ToLower());
    }

    public List<Score> GetScoresForPlayer(string name)
    {
        return _dataContext.Scores.Include(s => s.Player).Include(s => s.Game).Where(s => s.Player.Name.ToLower() == name.ToLower()).ToList();
    }

    public List<Score> GetScoresForGame(string title)
    {
        return _dataContext.Scores.Include(s => s.Game).Include(s => s.Player).Where(s => s.Game.Title.ToLower() == title.ToLower()).ToList();
    }

    public Score GetScoreForPlayerAndGame(string name, string title)
    {
        //return _dataContext.Scores.Include(s => s.Player)
        //    .Include(s => s.Game)
        //    .FirstOrDefault(s => s.Player.Name == name && s.Game.Title
        // == title);
        //var joined = _dataContext.Scores.Include(s => s.Player)
        //    .Include(s => s.Game).ToList();

        //.Where(s => s.Player.Name == name).ToList();
        //var result = subResult.FirstOrDefault(s => s.Game.Title.ToLower() == title.ToLower())
        //var a = joined.Where(s => s.Player.Name.ToLower() == name.ToLower()).ToList();
        //var b = a.Where(s => s.Game.Title.ToLower() == title.ToLower()).ToList();
        //return b[0];


        var result = _dataContext.Scores.Include(s => s.Player)
            .Include(s => s.Game)
            .FirstOrDefault(s => s.Player.Name.ToLower() == name.ToLower() && s.Game.Title.ToLower()
         == title.ToLower());
        return result;
    }

    public void AddPlayer(Player player)
    {
        _dataContext.Players.Add(player);
        _dataContext.SaveChanges();
    }

    public void AddGame(Game game)
    {
        _dataContext.Games.Add(game);
        _dataContext.SaveChanges();
    }

    public void AddScore(Score score)
    {
        _dataContext.Scores.Add(score);

        _dataContext.SaveChanges();
    }

    public void ChangeGenre(string title, string genre)
    {
        var game = GetGameForTitle(title);
        if (game != null)
        {
            game.Genre = genre;
        }
        _dataContext.SaveChanges();

    }
}
