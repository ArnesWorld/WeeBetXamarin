using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Services
{
    public interface IMatchDataService
    {
        List<Match> GetAllMatches();

        List<Match> GetMatchesByCompetitionId(int id);
    }
}
