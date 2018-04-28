using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeeBet.Core.Models{
    public class Odds
    {

        public int Id { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int MatchId { get; set; }

        public double Odds1 { get; set; }

        public double OddsX { get; set; }

        public double  Odds2 { get; set; }



    }
}