using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Npgsql;
using static System.Formats.Asn1.AsnWriter;

namespace DatabaseConnection;

public class GameScoreDatabaseContext : DbContext
{
    public GameScoreDatabaseContext() { }


    //public GameScoreDatabaseContext(DbContextOptions<GameScoreDatabaseContext> options) : base(options) { }
    
    public GameScoreDatabaseContext(DbContextOptions options) : base(options) { }


    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{ 
    //    options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Rgx---312");//hiányzott a port
    //}

    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }  
    public DbSet<Score> Scores { get; set; }

}
