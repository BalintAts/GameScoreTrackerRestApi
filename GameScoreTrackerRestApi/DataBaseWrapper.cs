using Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class DataBaseWrapper : IDataBaseWrapper
    {
        public IScore GetRecordScoreForPlayerForGame(string name, string title)
        {
            throw new NotImplementedException();
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
