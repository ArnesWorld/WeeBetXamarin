using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Repository
{
    public interface IFavouriteCompetitionsRepository
    {
        void AddCompetitonToFavourites(Competition competition);

        List<Competition> GetAllFavouriteCompetitionsBySportId(int sportId);

        void DeleteCompetitionFromFavourites(Competition competition);

        void Nuke();
    }
}
