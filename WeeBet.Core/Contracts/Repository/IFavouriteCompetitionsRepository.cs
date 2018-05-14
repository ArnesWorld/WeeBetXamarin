using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Repository
{
    public interface IFavouriteCompetitionsRepository
    {
        void AddMatchToFavourites(Competition match);

        List<Competition> GetAllFavouriteCompetitions();
    }
}
