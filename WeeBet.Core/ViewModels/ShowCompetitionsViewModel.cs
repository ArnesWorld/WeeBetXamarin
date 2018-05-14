using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using WeeBet.Core.Contracts.Repository;
using WeeBet.Core.Contracts.Services;
using WeeBet.Core.Models;

namespace WeeBet.Core.ViewModels
{
    public class ShowCompetitionsViewModel : MvxViewModel
    {
        private readonly ICompetitionsDataService _competitionDataService;

        private readonly IFavouriteCompetitionsRepository _favouriteCompetitionsRepository;
        private String SportName { get; set; }
        public IMvxCommand<Competition> RedirectToMatchesCommand { get; set; }

        public MvxObservableCollection<Competition> Competitions { get; set; }

        public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService, IFavouriteCompetitionsRepository favouriteCompetitionsRepository)
        {
            _favouriteCompetitionsRepository = favouriteCompetitionsRepository;
            _competitionDataService = competitionsDataService;   
        }

        public void Init(int sportId)
        {
           // SportName = sportName;
            Competitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(sportId));
            RedirectToMatchesCommand = new MvxCommand<Competition>(OnCompetitionSelected);
            List<Competition> competitions = _favouriteCompetitionsRepository.GetAllFavouriteCompetitions();
            int y = 9;
        }

        void OnCompetitionSelected (Competition competition)
        {
            ShowViewModel<ShowMatchesViewModel>(new { compId = competition.Id, compName = competition.Name });
        }

    }
}
