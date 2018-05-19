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
    public class FavouriteCompetitionsRepository : IFavouriteCompetitionsRepository
    {
        private readonly SQLiteConnection _connection;

        public FavouriteCompetitionsRepository(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Competition>();

        }
        public void AddCompetitonToFavourites(Competition competition)
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
