using System;
using System.Collections.Generic;
using WeeBet.Core.Contracts.Services;
using WeeBet.Core.Models;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WeeBet.Core.Services.DataServices
{
    public class CompetitionDataService : ICompetitionsDataService
    {
        private static string CompetitionsURL = "http://odds.arneralston.dk/api/competitions/";

        public List<Competition> GetCompetitionsBySportId(int id)
        {
            List<Competition> res = new List<Competition>();
            WebClient client = new WebClient();
            String page = client.DownloadString(CompetitionsURL + id);
            JArray competitions = JArray.Parse(page);
            foreach(var c in competitions)
            {
                Competition competition = JsonConvert.DeserializeObject<Competition>(c.ToString());
                res.Add(competition);
            }

            return res;
        }
    }
}
