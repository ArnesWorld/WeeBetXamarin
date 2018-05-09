using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Services.General
{
    public class CombinationCalculator
    {

        public VendorValue CalculateCombination(Dictionary<string, Match> matchOutcomes)
        {
            IEnumerable<string> outcomes = matchOutcomes.Keys;
            IEnumerable<Vendor> vendors = GetVendorsFromMatches(matchOutcomes.Values);

            VendorValue highest = new VendorValue();
            foreach(var currVendor in vendors)
            {
                double combRes = 1;
                foreach (var item in matchOutcomes)
                {
                    Match currMatch = item.Value;
                    string currOutcome = item.Key;

                    double oddsForOutcome = currMatch.GetOddsByVendor(currVendor).GetOddsByStringTag(currOutcome);
                    combRes = combRes * oddsForOutcome;
                }

                if(combRes > highest.Value)
                {
                    highest.Vendor = currVendor;
                    highest.Value = Math.Round(combRes,2);
                }
            }
            return highest;
        }

        public IEnumerable<Vendor> GetVendorsFromMatches(IEnumerable<Match> matches)
        {
            List<Vendor> res = new List<Vendor>();
            foreach  (Match m in matches)
            {
                foreach(Odds o in m.Odds)
                {
                    if (!res.Contains(o.Vendor))
                    {
                        res.Add(o.Vendor);
                    }
                }
            
            }
            return res;
        }



    }
}
