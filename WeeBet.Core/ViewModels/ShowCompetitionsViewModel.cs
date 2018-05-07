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
        private String CompName { get; set; }

        public MvxObservableCollection<Competition> Competitions { get; set; }

        public ShowCompetitionsViewModel(ICompetitionsDataService competitionsDataService)
        {
            _competitionDataService = competitionsDataService;
        }

        public void Init(string compName)
        {
            CompName = compName;
            Competitions = new MvxObservableCollection<Competition>(_competitionDataService.GetCompetitionsBySportId(1));
        }
    }
}
