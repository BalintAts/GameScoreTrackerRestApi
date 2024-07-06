using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseConnection
{
    public class GameScoreDatabaseContext : DbContext
    {
        public GameScoreDatabaseContext(DbContextOptions<GameScoreDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<MyEntity> MyEntities { get; set; }
    }
}
