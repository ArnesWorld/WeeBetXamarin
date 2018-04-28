using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeeBet.Core.Contracts.Services;
using WeeBet.Core.Models;

namespace WeeBet.Core.Services.DataServices
{
    public class MatchDataService : IMatchDataService
    {
        public ObservableCollection<Match> GetAllMatches()
        {
            Vendor v1 = new Vendor() { Id = 1, Name = "Unibet", Url = "www.unibet.dk" };
            Vendor v2 = new Vendor() { Id = 1, Name = "Ladbrokes", Url = "www.Ladbrokes.dk" };

            Contendent c1 = new Contendent() { Id = 1, Country = "England", Name = "Liverpool" };
            Contendent c2 = new Contendent() { Id = 2, Country = "England", Name = "Manchester City" };
            Contendent c3 = new Contendent() { Id = 3, Country = "England", Name = "Chelsea" };
            Contendent c4 = new Contendent() { Id = 4, Country = "England", Name = "Everton" };

            Odds o1 = new Odds() { Id = 1, Odds1 = 2.5, Odds2 = 5.3, OddsX = 1.6, Vendor = v1 };
            Odds o2 = new Odds() { Id = 2, Odds1 = 7.5, Odds2 = 3.3, OddsX = 1.9, Vendor = v2 };
            Odds o3 = new Odds() { Id = 3, Odds1 = 4.5, Odds2 = 2.7, OddsX = 6.5, Vendor = v1 };
            Odds o4 = new Odds() { Id = 4, Odds1 = 3.5, Odds2 = 3.3, OddsX = 3.1, Vendor = v2 };

            List<Odds> odds1 = new List<Odds>();
            odds1.Add(o1);
            odds1.Add(o2);

            List<Odds> odds2 = new List<Odds>();
            odds2.Add(o3);
            odds2.Add(o4);

            ObservableCollection<Match> res = new ObservableCollection<Match>();
            Match m1 = new Match() { Id = 1, ContendentAway = c2, ContendentHome = c1, Time = DateTime.Now, Odds = odds1};
            Match m2 = new Match() { Id = 2, ContendentAway = c3, ContendentHome = c4, Time = DateTime.Now, Odds = odds2 };
            res.Add(m1);
            res.Add(m2);

            return res;
        }
    }
}
