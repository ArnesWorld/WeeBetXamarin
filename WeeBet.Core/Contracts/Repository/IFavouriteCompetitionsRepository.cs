using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Repository
{
    public interface FavouriteCompetitionsRepository
    {
        void AddMatchToFavourites(Competition competition);

        List<Competition> GetAllFavouriteCompetitions();

        void DeleteCompetitionFromFavourites(Competition competition);

        void Nuke();
    }
}
