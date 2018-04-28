using System;
using System.Collections.Generic;

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

    }
}