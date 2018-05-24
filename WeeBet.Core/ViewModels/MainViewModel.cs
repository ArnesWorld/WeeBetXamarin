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
    public class MainViewModel : MvxViewModel
    {
        public IMvxCommand ShowMatchesCommand { get; set; }
        public IMvxCommand<int> ShowCompetitionsCommand { get; set; }

        protected readonly IConnectivityService _connectivityService;
        protected readonly IDialogService _dialogService;

        public MainViewModel(IConnectivityService connectivityService, IDialogService dialogService)
        {
            _connectivityService = connectivityService;
            _dialogService = dialogService;
            ShowCompetitionsCommand = new MvxCommand<int>((id) =>
            {
                bool online = _connectivityService.CheckOnline();
                if (_connectivityService.CheckOnline())
                {
                    string sName = GetSportNameById(id);
                    ShowViewModel<ShowCompetitionsViewModel>(new { sportId = id, sportName = sName });
                }
                else
                {
                    _dialogService.ShowAlert("Please connect to internet and try again","No Internet Connection", "OK");
                }
            });

            ShowMatchesCommand = new MvxCommand(() => {
                Competition c = new Competition() { Name = "Premier League" };
                ShowViewModel<ShowMatchesViewModel>(new {compName = "Premier League" });
            });           
        }

        private string GetSportNameById(int id)
        {
            switch (id)
            {
                case 1: return "Soccer";
                case 2: return "Hockey";
                case 3: return "Tennis";
                case 4: return "Basketball";
                case 5: return "Swimming";
                case 6: return "Fencing";
                default: return "";
            };
        }

        public class DetailParameters
        {

        }
    }
}
