using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeeBet.Core.Models
{
    public class MatchHeader : MvxObservableCollection<Odds>
    {
        public Match Match { get; set; }
        public string Title { get; set; }

        public MatchHeader(Match match)
        {
            this.Match = match;
            foreach(Odds o in match.Odds)
            {
                this.Add(o);
            }

           
        }
    }
}
