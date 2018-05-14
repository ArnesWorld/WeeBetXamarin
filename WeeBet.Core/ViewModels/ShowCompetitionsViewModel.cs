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

        protected readonly ICompetitionsDataService _competitionDataService;
        protected readonly IFavouriteCompetitionsRepository _favouriteCompetitionsRepository;

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
        

        private MvxCommand<Competition> _memoryLongClickCommand;
        public IMvxCommand MemoryLongClickCommand
        {
            get { return _memoryLongClickCommand ?? (_memoryLongClickCommand = new MvxCommand<Competition>(AddRemoveFavourites)); }
        }

        void AddRemoveFavourites(Competition selectedMemory)
        {
            int a = 9;
        }

       public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService, IFavouriteCompetitionsRepository favouriteCompetitionsRepository)
        {
            _competitionDataService = competitionsDataService;
            _favouriteCompetitionsRepository = favouriteCompetitionsRepository;
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
