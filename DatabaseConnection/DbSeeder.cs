//using Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DatabaseConnection;

//public static class DbSeeder
//{
//    public static void Seed(GameScoreDatabaseContext context)
//    {
//        if (context.Database.IsInMemory())
//        {
//            var playar1 = new Player { Id = 1, Name = "Alice", Birthdate = new DateTime(2000, 1, 1) };
//            var playar2 = new Player { Id = 2, Name = "Bob", Birthdate = new DateTime(2000, 1, 1) };
//            var playar3 = new Player { Id = 3, Name = "Charlie", Birthdate = new DateTime(2000, 1, 1) };

//            context.Players.Add(playar1);
//            context.Players.Add(playar2);
//            context.Players.Add(playar3);


//            var game1 = new Game { Id = 1, Title = "Doom", Genre = "Shooter " };
//            var game2 = new Game { Id = 2, Title = "Need For Speed", Genre = "Car" };
//            var game3 = new Game { Id = 3, Title = "Portal", Genre = "Puzzle" };

//            context.Games.Add(game1);
//            context.Games.Add(game2);
//            context.Games.Add(game3);


//            var score1 = new Score { Id = 1, Player = playar1, Game = game1, ScoreValue = 1000 };
//            var score2 = new Score { Id = 2, Player = playar1, Game = game2, ScoreValue = 2000 };
//            var score3 = new Score { Id = 3, Player = playar1, Game = game3, ScoreValue = 3000 };

//            var score4 = new Score { Id = 4, Player = playar2, Game = game1, ScoreValue = 4000 };
//            var score5 = new Score { Id = 5, Player = playar2, Game = game2, ScoreValue = 5000 };
//            var score6 = new Score { Id = 6, Player = playar2, Game = game3, ScoreValue = 6000 };

//            var score7 = new Score { Id = 7, Player = playar3, Game = game1, ScoreValue = 7000 };
//            var score8 = new Score { Id = 8, Player = playar3, Game = game2, ScoreValue = 8000 };
//            var score9 = new Score { Id = 9, Player = playar3, Game = game3, ScoreValue = 9000 };

//            context.Scores.Add(score1);
//            context.Scores.Add(score2);
//            context.Scores.Add(score3);
//            context.Scores.Add(score4);
//            context.Scores.Add(score5);
//            context.Scores.Add(score6);
//            context.Scores.Add(score7);
//            context.Scores.Add(score8);
//            context.Scores.Add(score9);

//            context.SaveChanges();
//        }
//    }
//}
