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
        public IMvxCommand<Competition> RedirectToMatchesCommand { get; set; }

        public MvxObservableCollection<Competition> Competitions { get; set; }

        private MvxCommand<Competition> _memoryLongClickCommand;
        public IMvxCommand MemoryLongClickCommand
        {
            get { return _memoryLongClickCommand ?? (_memoryLongClickCommand = new MvxCommand<Competition>(AddRemoveFavourites)); }
        }

        void AddRemoveFavourites(Competition selectedMemory)
        {
            int a = 9;
        }

        public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService)
        {
            _competitionDataService = competitionsDataService;
        }

        public void Init(int sportId)
        {
           // SportName = sportName;
            Competitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(sportId));
            RedirectToMatchesCommand = new MvxCommand<Competition>(OnCompetitionSelected);
            
        }

        void OnCompetitionSelected (Competition competition)
        {
            ShowViewModel<ShowMatchesViewModel>(new { compId = competition.Id, compName = competition.Name });
        }

    }
}
