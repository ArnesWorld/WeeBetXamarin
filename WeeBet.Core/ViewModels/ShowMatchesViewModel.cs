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

        public string HelloText { get; set; }
        public ObservableCollection<Match> Matches { get; set; }

        public ShowMatchesViewModel(IMatchDataService matchDataService)
        {
            _matchDataService = matchDataService;
            Matches = (ObservableCollection<Match>)_matchDataService.GetAllMatches();
            string text = Matches[0].ContendentAway.Name;
            HelloText = text;
            int y = 8;
        }
    }
}
