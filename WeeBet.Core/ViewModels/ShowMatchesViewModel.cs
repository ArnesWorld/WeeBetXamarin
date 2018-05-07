using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using WeeBet.Core.Contracts.Services;
using WeeBet.Core.Models;

namespace WeeBet.Core.ViewModels
{
    public class ShowMatchesViewModel : MvxViewModel
    {
        private readonly IMatchDataService _matchDataService;

        public String CompName { get; set; }

        private MvxObservableCollection<MatchHeader> _matches;
        public MvxObservableCollection<MatchHeader> Matches
        {
            get { return _matches; }
            set
            {
                SetProperty(ref _matches, value);
            }
        }

        public ShowMatchesViewModel(IMatchDataService matchDataService)
        {
            _matchDataService = matchDataService;
        }

        public void Init(string compName, int compId)
        {

            CompName = compName;
            Matches = new MvxObservableCollection<MatchHeader>();

            List<Match> matchList = _matchDataService.GetMatchesByCompetitionId(compId);
            foreach (var m in matchList)
            {
                MatchHeader currMatchHeader = new MatchHeader(m);

                Matches.Add(new MatchHeader(m));
            }
        
        }



    }
}
