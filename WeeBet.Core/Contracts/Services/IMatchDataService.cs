using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Services
{
    public interface IMatchDataService
    {
        ObservableCollection<Match> GetAllMatches();
    }
}
