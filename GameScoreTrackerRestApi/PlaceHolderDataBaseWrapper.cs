using GameScoreTrackerRestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class PlaceHolderDataBaseWrapper /*: IDataBaseWrapper*/
    {
        public Score GetRecordScoreForPlayerForGame(string name, string title)
        {
            return new Score();
        }

        public List<Score> GetRecordScoresForGame(string title)
        {
            throw new NotImplementedException();
        }

        public List<Score> GetRecordScoresForPlayer(string name)
        {
            //if (score == null)
            //{
            //    throw new Exception($"No score for game {title} for player {name}");
            //}
            throw new NotImplementedException();
        }
    }
}
