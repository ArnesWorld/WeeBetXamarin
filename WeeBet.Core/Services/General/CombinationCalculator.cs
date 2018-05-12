using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeeBet.Core.Models;
using WeeBet.Core.Contracts.Services;

namespace WeeBet.Core.Services.General
{
    public class CombinationCalculator : ICombinationCalculatorService
    {
        public CombinationCalculator()
        {

        }

        public VendorValue CalculateCombination(Dictionary<Match, string> matchOutcomes)
        {
            IEnumerable<string> outcomes = matchOutcomes.Values;
            IEnumerable<Vendor> vendors = GetVendorsFromMatches(matchOutcomes.Keys);

            VendorValue highest = new VendorValue();
            foreach(var currVendor in vendors)
            {
                double combRes = 1;
                foreach (var item in matchOutcomes)
                {
                    Match currMatch = item.Key;
                    string currOutcome = item.Value;

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
                    bool isAllreadyInList = res.Any(v => v.Name.Equals(o.Vendor.Name));
                    if (!isAllreadyInList)
                    {
                        res.Add(o.Vendor);
                    }
                }
            
            }
            return res;
        }



    }
}
