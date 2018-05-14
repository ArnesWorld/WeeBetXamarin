using MvvmCross.Plugins.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Contracts.Repository;
using WeeBet.Core.Models;


namespace WeeBet.Core.Repository
{
    public class FavouriteCompetitionRepository : IFavouriteCompetitionsRepository
    {
        private readonly SQLiteConnection _connection;

        public FavouriteCompetitionRepository(IMvxSqliteConnectionFactory sqliteConnectionFactory)
        {
            _connection = sqliteConnectionFactory.GetConnection("WeeBetDb");
            _connection.CreateTable<Competition>();

        }
        public void AddMatchToFavourites(Competition match)
        {
            _connection.Insert(match);
        }

        public List<Competition> GetAllFavouriteCompetitions()
        {
            // var query = _connection.Table<Competition>().To;
            return null;
           
        }
    }
}
