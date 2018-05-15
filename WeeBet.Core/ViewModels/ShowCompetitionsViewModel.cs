using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private int _sportId;
     
        public String favoriteText = "Favorites:";
        public IMvxCommand<Competition> RedirectToMatchesCommand { get; set; }

        public MvxObservableCollection<Competition> Competitions { get; set; }

        private MvxObservableCollection<Competition> favouriteCompetitions;
        public MvxObservableCollection<Competition> FavouriteCompetitions 
        {
            get { return favouriteCompetitions; }
            set { favouriteCompetitions = value;
                RaisePropertyChanged(() => FavouriteCompetitions);
            }
        }



        private bool isFavoritesVisible;
        private string sportName;
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
        

        private MvxCommand<Competition> _competitionClickCommand;
        public IMvxCommand CompetitionLongClickCommand
        {
            get { return _competitionClickCommand ?? (_competitionClickCommand = new MvxCommand<Competition>(AddRemoveFavourites)); }
        }

        void AddRemoveFavourites(Competition selectedCompetition)
        {

            if (FavouriteCompetitions.Where(c => c.Id == selectedCompetition.Id).Any())
            {
                _favouriteCompetitionsRepository.DeleteCompetitionFromFavourites(selectedCompetition);
            }
            else
            {
                _favouriteCompetitionsRepository.AddMatchToFavourites(selectedCompetition);
            }
            LoadFavouriteCompetitons(_sportId);
        }

       public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService, IFavouriteCompetitionsRepository favouriteCompetitionsRepository)
        {
            _competitionDataService = competitionsDataService;
            _favouriteCompetitionsRepository = favouriteCompetitionsRepository;
        }

        public void Init(int sportId, string sportName)
        {
             SportName = sportName;
            _sportId = sportId;
            _favouriteCompetitionsRepository.Nuke();
            Competitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(sportId));
            LoadFavouriteCompetitons(_sportId);
            RedirectToMatchesCommand = new MvxCommand<Competition>(OnCompetitionSelected);

            
        }

        void OnCompetitionSelected (Competition competition)
        {
            ShowViewModel<ShowMatchesViewModel>(new { compId = competition.Id, compName = competition.Name });
        }

        private void LoadFavouriteCompetitons(int sportId)
        {
            FavouriteCompetitions = new MvxObservableCollection<Competition>(_favouriteCompetitionsRepository.GetAllFavouriteCompetitionsBySportId(sportId));
            SetFavoriteVisivility();
        }

        void SetFavoriteVisivility()
        {
            if (FavouriteCompetitions.Count > 0)
            {
                IsFavoritesVisible = true;
            }
            else
            {
                IsFavoritesVisible = false;
            }
        }

    }
}
