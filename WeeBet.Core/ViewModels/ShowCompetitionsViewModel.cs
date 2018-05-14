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

        private ICompetitionsDataService _competitionDataServiceForFavorites;
        public String sportName = "Soccer";
        public String favoriteText = "Your Favorites:";
        public IMvxCommand<Competition> RedirectToMatchesCommand { get; set; }

        public MvxObservableCollection<Competition> Competitions { get; set; }
        public MvxObservableCollection<Competition> FavouriteCompetitions { get; set; }

        private bool isFavoritesVisible;

        public string SportName
        {
            get { return sportName; }
            set
            {
                sportName = value;
                RaisePropertyChanged(() => SportName);
            }
        }

        public string FavoriteText
        {
            get { return favoriteText; }
            set
            {
                favoriteText = value;
                RaisePropertyChanged(() => FavoriteText);
            }
        }

        public bool IsFavoritesVisible
        {
            get { return isFavoritesVisible; }
            set
            {
                isFavoritesVisible = value;
                RaisePropertyChanged(() => IsFavoritesVisible);
            }
        }

        public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService)
        {
            _competitionDataService = competitionsDataService;
            //_competitionDataServiceForFavorites = competitionDataServiceForFavorites;
        }

        public void Init(int sportId)
        {
           // SportName = sportName;
            Competitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(sportId));
            FavouriteCompetitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(sportId));
            RedirectToMatchesCommand = new MvxCommand<Competition>(OnCompetitionSelected);

            SetFavoriteVisivility();
            
        }

        void OnCompetitionSelected (Competition competition)
        {
            ShowViewModel<ShowMatchesViewModel>(new { compId = competition.Id, compName = competition.Name });
        }

        void SetFavoriteVisivility()
        {
            if (FavouriteCompetitions.Count > 0)
            {
                IsFavoritesVisible = true;
            }
        }

    }
}
