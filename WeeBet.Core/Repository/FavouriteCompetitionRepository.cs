using MvvmCross.Plugins.Sqlite;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeeBet.Core.Contracts.Repository;
using WeeBet.Core.Models;


namespace WeeBet.Core.Repository
{
    public class FavouriteCompetitionRepository : IFavouriteCompetitionsRepository
    {
        private readonly SQLiteConnection _connection;

        //public FavouriteCompetitionRepository()
        //{

        //}
        public FavouriteCompetitionRepository(IMvxSqliteConnectionFactory sqliteConnectionFactory)
        {
            _connection = sqliteConnectionFactory.GetConnection("WeeBetDb");
            _connection.CreateTable<Competition>();

        }
        public void AddMatchToFavourites(Competition competition)
        {
            _connection.Insert(competition);
            
        }

        public void DeleteCompetitionFromFavourites(Competition competition)
        {
            _connection.Delete(competition);
        }

        public List<Competition> GetAllFavouriteCompetitionsBySportId(int sportId)
        {
            List<Competition> res = new List<Competition>();
            var favComps = _connection.Table<Competition>().Where(c => c.SportID == sportId);
            foreach (var item in favComps)
            {
                Competition currComp = (Competition)item;
                res.Add(currComp);
            }
            return res; 
           
        }

        //public Task<List<Match>> GetAllFavouriteCompetitionsBySportIdAsync(int sportId)
        //{
        //    List<Competition> res = new List<Competition>();
        //    var favComps = _connection.Table<Competition>().Where(c => c.SportID == sportId);
        //    foreach (var item in favComps)
        //    {
        //        Competition currComp = (Competition)item;
        //        res.Add(currComp);
        //    }
        //    return res;

        //}

        public void Nuke()
        {
            _connection.DeleteAll<Competition>();
                
        }
    }
}
