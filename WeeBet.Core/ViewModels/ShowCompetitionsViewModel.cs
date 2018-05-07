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
    public class ShowCompetitionsViewModel : MvxViewModel
    {
        private readonly ICompetitionsDataService _competitionDataService;
        private String SportName { get; set; }
        public MvxCommand<Competition> RedirectToMatches { get; set; }

        public MvxObservableCollection<Competition> Competitions { get; set; }

        public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService)
        {
            _competitionDataService = competitionsDataService;
        }

        public void Init(string sportName)
        {
            SportName = sportName;
            Competitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(1));
            RedirectToMatches = new MvxCommand<Competition>(OnCompetitionSelected);
        }

        void OnCompetitionSelected (Competition competition)
        {
            ShowViewModel<ShowMatchesViewModel>(new { id = competition.Id, compName = competition.Name });
        }

    }
}
