using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WeeBet.Core.Models
{
    public class Match
    {

        public int Id { get; set; }

        public int ContendentHomeID { get; set; }
        public virtual Contendent ContendentHome { get; set; }
        public int ContendentAwayID { get; set; }
        public virtual Contendent ContendentAway { get; set; }

        public DateTime Time { get; set; }
        public virtual List<Odds> Odds { get; set; }
        public int CompetitionID { get; set; }

        public Match()
        {
            Odds = new List<Odds>();
        }

        public Odds GetOddsByVendor(Vendor vendor)
        {
           return Odds.FirstOrDefault( o => o.Vendor.Name.Equals(vendor.Name));
        }

    }
}