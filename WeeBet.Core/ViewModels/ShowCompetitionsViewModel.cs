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

        public MvxObservableCollection<CompetitionHeader> Competitions
        {
            get { return _competitions; }
            set
            {
                SetProperty(ref _competitions, value);
            }
        }

        public void Init(string compName)
        {
            CompName = compName;
            Competitions = new MvxObservableCollection<CompetitionHeader>();

            List<Competition> compeitionList = _competitionDataService.GetCompetitionsBySportId(1);
            foreach (var c in compeitionList)
            {
                CompetitionHeader currCompetitionHeader = new CompetitionHeader(c);

                Competitions.Add(new MatchHeader(m));
            }
        }
    }
}
