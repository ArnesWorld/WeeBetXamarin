using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeeBet.Core.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Competition> Competitions { get; set; }

        public Sport()
        {
            Competitions = new List<Competition>();
        }
    }
}