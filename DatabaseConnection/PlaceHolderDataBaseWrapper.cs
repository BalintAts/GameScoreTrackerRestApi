using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class PlaceHolderDataBaseWrapper : IDataBaseWrapper
    {
        public IScore GetRecordScoreForPlayerForGame(string name, string title)
        {
            return new Score();
        }

        public List<IScore> GetRecordScoresForGame(string title)
        {
            throw new NotImplementedException();
        }

        public List<IScore> GetRecordScoresForPlayer(string name)
        {
            throw new NotImplementedException();
        }
    }
}
