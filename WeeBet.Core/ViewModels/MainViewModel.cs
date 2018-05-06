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
        public IMvxCommand ShowCompetitionsCommand { get; set; }
    
        public MainViewModel()
        {
            ShowCompetitionsCommand = new MvxCommand(() =>
            {
                Sport s = new Sport() { Name = "Soccer" };
                ShowViewModel<ShowCompetitionsViewModel>(new { compName = "Soccer"});

            });

            ShowMatchesCommand = new MvxCommand(() => {
                Competition c = new Competition() { Name = "Premier League" };
                ShowViewModel<ShowMatchesViewModel>(new {compName = "Premier League" });
            });           
        }

        public class DetailParameters
        {

        }
    }
}
