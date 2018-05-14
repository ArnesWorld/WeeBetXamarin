using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeeBet.Core.Models
{
    public class MatchHeader : MvxObservableCollection<OddsItemViewModel>
    {
        public Match Match { get; set; }
        public string Title { get; set; }

        public MatchHeader(Match match)
        {
            this.Match = match;
           // this.AddRange(match.Odds);
        }
    }
}
