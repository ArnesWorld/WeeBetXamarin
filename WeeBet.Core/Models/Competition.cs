
    using System;
    using System.Collections.Generic;

namespace WeeBet.Core.Models
{
    public class Competition
    {
 
        public int Id { get; set; }
        public string Name { get; set; }
        public int SportID { get; set; }
        public string Country { get; set; }

        public List<Match> Matches { get; set; }

        public Competition()
        {
            Matches = new List<Match>();
        }
    }


}
